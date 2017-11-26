using System.ComponentModel.DataAnnotations;

namespace Onion.Web.Features.Account.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
