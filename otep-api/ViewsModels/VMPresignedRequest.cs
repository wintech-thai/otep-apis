using System.Diagnostics.CodeAnalysis;

namespace Its.Otep.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMPresignedRequest : VMQueryBase
    {
        public string? FileName { get; set; }
        public string? DocumentType { get; set; }
    }
}
