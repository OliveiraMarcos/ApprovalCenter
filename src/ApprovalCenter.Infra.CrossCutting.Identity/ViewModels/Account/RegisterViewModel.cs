using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApprovalCenter.Infra.CrossCutting.Identity.ViewModels.Account
{
    public class RegisterViewModel : PasswordViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


    }
}
