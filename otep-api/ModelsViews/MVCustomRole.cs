using System.Diagnostics.CodeAnalysis;
using Its.Otep.Api.Models;

namespace Its.Otep.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVCustomRole
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MCustomRole? CustomRole { get; set; }
    }
}
