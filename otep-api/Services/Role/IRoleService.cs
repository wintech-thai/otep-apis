using Its.Otep.Api.Models;
using Its.Otep.Api.ViewsModels;

namespace Its.Otep.Api.Services
{
    public interface IRoleService
    {
        public IEnumerable<MRole> GetRolesList(string orgId, string rolesList);
        public IEnumerable<MRole> GetRoles(string orgId, VMRole param);
    }
}
