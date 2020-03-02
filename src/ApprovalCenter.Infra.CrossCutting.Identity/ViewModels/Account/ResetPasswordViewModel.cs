using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApprovalCenter.Infra.CrossCutting.Identity.ViewModels.Account
{
    public class ResetPasswordViewModel : PasswordViewModel
    {
        [Required]
        [Display(Name = "Token Password")]
        public string TokenPassword { get; set; }
    }
}
