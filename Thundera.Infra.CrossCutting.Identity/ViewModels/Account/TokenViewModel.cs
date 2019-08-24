using System;
using System.ComponentModel.DataAnnotations;

namespace Thundera.Infra.CrossCutting.Identity.ViewModels.Account
{
    public class TokenViewModel
    {
        public TokenViewModel(string email, string token, DateTime expiration)
        {
            Email = email;
            Token = token;
            Expiration = expiration;
        }
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
