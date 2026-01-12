using System.Diagnostics.CodeAnalysis;
using Its.Otep.Api.Models;

namespace Its.Otep.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVOrganization
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MOrganization? Organization { get; set; }
    }
}
