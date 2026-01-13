using System.Diagnostics.CodeAnalysis;

namespace Its.Otep.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMApiKey : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
