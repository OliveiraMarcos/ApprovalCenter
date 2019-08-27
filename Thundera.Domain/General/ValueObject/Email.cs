using System.Text.RegularExpressions;
using Thundera.Domain.Core.Models;

namespace Thundera.Domain.General.ValueObject
{
    public class Email : ValueObject<Email>
    {
        public const int ValueEmailMax = 254;
        public string Address { get; protected set; }
        protected Email()
        {

        }
        public Email(string email)
        {
            Address = email;
        }
        protected override bool EqualsCore(Email other)
        {
            return Address.Equals(other.Address);
        }

        protected override int GetHashCodeCore()
        {
            return (GetType().GetHashCode() * 907) ^ Address.GetHashCode();
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
