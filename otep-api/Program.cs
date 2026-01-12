using Serilog;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Its.Otep.Api.Database.Seeders;
using Its.Otep.Api.Database;
using StackExchange.Redis;
using Its.Otep.Api.Utils;
using Its.Otep.Api.Database.Repositories;
using Its.Otep.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Its.Otep.Api.Authorizations;
using Its.Otep.Api.Authentications;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;


namespace Its.Otep.Api
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        public static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger = log;


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);


            var cfg = builder.Configuration;
            var connStr = $"Host={cfg["PostgreSQL:Host"]}; Database={cfg["PostgreSQL:Database"]}; Username={cfg["PostgreSQL:User"]}; Password={cfg["PostgreSQL:Password"]}";


            var redisHostStr = $"{cfg["Redis:Host"]}:{cfg["Redis:Port"]}"; 
            builder.Services.AddSingleton<IConnectionMultiplexer>(
                sp => ConnectionMultiplexer.Connect(redisHostStr));

            builder.Services.AddScoped<RedisHelper>();

            builder.Services.AddSingleton(sp =>
            {
                // ถ้าใช้ service account json
                var storageClient = StorageClient.Create(
                    GoogleCredential.FromFile(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"))
                );

                return storageClient;
            });
            builder.Services.AddSingleton(sp =>
            {
                return GoogleCredential.FromFile(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"))
                                    .CreateScoped("https://www.googleapis.com/auth/cloud-platform");
            });
            builder.Services.AddSingleton<IRedisHelper, RedisHelper>();
            builder.Services.AddSingleton<IStorageUtils, StorageUtils>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connStr, o => o.CommandTimeout(1200)));
            builder.Services.AddTransient<DataSeeder>();

            builder.Services.AddScoped<IDataContext, DataContext>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();


            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IOrganizationService, OrganizationService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrganizationUserRepository, OrganizationUserRepository>();
            

            builder.Services.AddTransient<IAuthorizationHandler, GenericRbacHandler>();
            builder.Services.AddScoped<IBasicAuthenticationRepo, BasicAuthenticationRepo>();
            builder.Services.AddScoped<IBearerAuthenticationRepo, BearerAuthenticationRepo>();

            builder.Services.AddHttpClient();
            builder.Services.AddHealthChecks();


            builder.Services.AddAuthentication("BasicOrBearer")
                .AddScheme<AuthenticationSchemeOptions, AuthenticationHandlerProxy>("BasicOrBearer", null);

            builder.Services.AddAuthorization(options => {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder("BasicOrBearer");
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

                options.AddPolicy("GenericRolePolicy", policy => policy.AddRequirements(new GenericRbacRequirement()));
            });
            
            // เปิด middleware สำหรับ gzip
            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true; // ให้บีบอัดแม้เป็น HTTPS
                options.Providers.Add<GzipCompressionProvider>();
            });
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                dbContext.Database.Migrate();

                var service = scope.ServiceProvider.GetRequiredService<DataSeeder>();
                service.Seed();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
