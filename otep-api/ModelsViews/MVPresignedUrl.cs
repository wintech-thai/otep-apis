using System.Diagnostics.CodeAnalysis;
using Its.Otep.Api.Services;

namespace Its.Otep.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVPresignedUrl
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public PresignedPostResult? PresignedResult { get; set; }
    }
}
