using Microsoft.EntityFrameworkCore;
using Its.Otep.Api.Models;

namespace Its.Otep.Api.Database
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public DbSet<MOrganization>? Organizations { get; set; }
        public DbSet<MMasterRef>? MasterRefs { get; set; }
        public DbSet<MRole>? Roles { get; set; }
        public DbSet<MApiKey>? ApiKeys { get; set; }
        public DbSet<MUser>? Users { get; set; }
        public DbSet<MOrganizationUser>? OrganizationUsers { get; set; }
        public DbSet<MCustomRole>? CustomRoles { get; set; }
    }
}