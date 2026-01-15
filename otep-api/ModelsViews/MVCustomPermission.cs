using System.Diagnostics.CodeAnalysis;
using Its.Otep.Api.Models;

namespace Its.Otep.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVCustomPermission
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public List<ControllerNode> Permissions { get; set; } //structure เหมือนกับใน MCustomRole

        public MVCustomPermission()
        {
            Permissions = [];
        }
    }
}
