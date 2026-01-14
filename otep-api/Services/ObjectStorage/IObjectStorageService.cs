namespace Its.Otep.Api.Services
{
    public interface IObjectStorageService
    {
        public Task<PresignedPostResult> GetPresignedUrlPost(string bucket, string path, int secDurationExpire);
        public Task<string> GetPresignedUrlGet(string bucket, string path, int secDurationExpire);
    }
}
