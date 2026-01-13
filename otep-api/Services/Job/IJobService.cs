using Its.Otep.Api.Models;
using Its.Otep.Api.ModelsViews;
using Its.Otep.Api.ViewsModels;

namespace Its.Otep.Api.Services
{
    public interface IJobService
    {
        public MJob? GetJobById(string orgId, string itemId);
        public MJob GetJobTemplate(string orgId, string jobType, string userName);
        public MVJob? AddJob(string orgId, MJob item);
        public IEnumerable<MJob> GetJobs(string orgId, VMJob param);
        public int GetJobCount(string orgId, VMJob param);
        public MVJob? DeleteJobById(string orgId, string jobId);
    }
}
