using Its.Otep.Api.Models;
using Its.Otep.Api.ViewsModels;

namespace Its.Otep.Api.Database.Repositories
{
    public interface IRoleRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public IEnumerable<MRole> GetRolesList(string rolesList);
        public IEnumerable<MRole> GetRoles(VMRole param);
    }
}
