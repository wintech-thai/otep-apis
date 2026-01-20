using System.Diagnostics.CodeAnalysis;
using Its.Otep.Api.Models;

namespace Its.Otep.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVOrganizationUserRegistration
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public string? RegistrationUrl { get; set; }
        public string? ForgotPasswordUrl { get; set; }
    }
}
