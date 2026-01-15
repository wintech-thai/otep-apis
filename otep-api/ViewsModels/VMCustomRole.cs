using System.Diagnostics.CodeAnalysis;

namespace Its.Otep.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMCustomRole : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
        public string? Level { get; set; }
    }
}
