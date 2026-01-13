using System.Diagnostics.CodeAnalysis;

namespace Its.Otep.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMDocument : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
