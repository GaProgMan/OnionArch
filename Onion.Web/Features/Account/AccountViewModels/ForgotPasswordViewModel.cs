using System.ComponentModel.DataAnnotations;

namespace Onion.Web.Features.Account.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
