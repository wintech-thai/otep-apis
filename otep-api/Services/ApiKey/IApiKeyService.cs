using Its.Otep.Api.Models;
using Its.Otep.Api.ModelsViews;
using Its.Otep.Api.ViewsModels;

namespace Its.Otep.Api.Services
{
    public interface IApiKeyService
    {
        public Task<MApiKey> GetApiKey(string orgId, string apiKey);
        public Task<MApiKey> GetApiKeyByName(string orgId, string keyName);
        public MVApiKey VerifyApiKey(string orgId, string apiKey);
        public MVApiKey? AddApiKey(string orgId, MApiKey apiKey);
        public MVApiKey? DeleteApiKeyById(string orgId, string keyId);
        public IEnumerable<MApiKey> GetApiKeys(string orgId, VMApiKey param);

        public int GetApiKeyCount(string orgId, VMApiKey param);
        public MVApiKey? UpdateApiKeyById(string orgId, string keyId, MApiKey apiKey);
        public Task<MVApiKey> GetApiKeyById(string orgId, string keyId);
        public MVApiKey? UpdateApiKeyStatusById(string orgId, string keyId, string status);
    }
}
