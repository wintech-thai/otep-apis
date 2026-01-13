using System.Diagnostics.CodeAnalysis;

namespace Its.Otep.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMOrganizationUser : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
