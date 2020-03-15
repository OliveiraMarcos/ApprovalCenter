using System;
using System.ComponentModel.DataAnnotations;

namespace ApprovalCenter.Infra.CrossCutting.Identity.ViewModels.Account
{
    public class TokenViewModel
    {
        public TokenViewModel(string username,string email, string token, DateTime expiration)
        {
            UserName = username;
            Email = email;
            Token = token;
            Expiration = expiration;
        }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
