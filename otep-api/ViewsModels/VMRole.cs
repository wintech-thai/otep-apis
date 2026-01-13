using System.Diagnostics.CodeAnalysis;

namespace Its.Otep.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMRole : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
