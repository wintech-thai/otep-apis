using Microsoft.IdentityModel.Tokens;

namespace Its.Otep.Api.Services
{
    public interface IJwtSigner
    {
        public SecurityKey GetSignedKey(string? url);
    }
}
