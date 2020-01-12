using System;
using System.Linq;
using AprovationCenter.Domain.Core.Models;

namespace AprovationCenter.Domain.General.ValueObject
{
    public class CpfVO : ValueObject<CpfVO>
    {
        public const int LengthMaxCpf = 11;
        public string Code { get; protected set; }
        protected CpfVO()
        {

        }
        public CpfVO(string cpf)
        {
            Code = cpf;
        }

        public static string GetCpfClean(string cpf)
        {
            cpf = String.Join("", cpf.Where(Char.IsDigit));
            if (string.IsNullOrEmpty(cpf))
                return "";
            while (cpf.StartsWith("0"))
                cpf = cpf.Substring(1);
            return cpf;
        }

        public string GetCpfFull()
        {
            var cpf = Code;
            if (string.IsNullOrEmpty(cpf))
                return "";
            while (cpf.Length < LengthMaxCpf)
                cpf = "0" + cpf;
            return cpf;
        }

        public static bool IsValid(string cpf)
        {
            cpf = String.Join("", cpf.Where(Char.IsDigit));
            if (cpf.Length < LengthMaxCpf)
                return false;

            while (cpf.Length < LengthMaxCpf)
                cpf = "0" + cpf;

            var equal = true;
            for (int i = 1; i < LengthMaxCpf && equal; i++)
                if (cpf[i] != cpf[0])
                    equal = false;
            if (equal || cpf == "12345678909")
                return false;

            var baseNumbers = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum = 0;
            for (int i = 1; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cpf[i - 1].ToString());

            var result = sum % 11;

            if (result < 2)
            {
                if (!"0".Equals(cpf[LengthMaxCpf - 2].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cpf[LengthMaxCpf - 2].ToString())
                return false;

            sum = 0;
            for (int i = 0; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cpf[i].ToString());

            result = sum % 11;
            if (result < 2)
            {
                if (!"0".Equals(cpf[LengthMaxCpf - 1].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cpf[LengthMaxCpf - 1].ToString())
                return false;
            return true;
        }

        protected override bool EqualsCore(CpfVO other)
        {
            return Code.Equals(other.Code);
        }

        protected override int GetHashCodeCore()
        {
            return (GetType().GetHashCode() * 907) ^ Code.GetHashCode();
        }
    }
}
