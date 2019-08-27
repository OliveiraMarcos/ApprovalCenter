using System;
using System.Linq;
using Thundera.Domain.Core.Models;

namespace Thundera.Domain.General.ValueObject
{
    public class CPF : ValueObject<CPF>
    {
        public const int ValueMaxCpf = 11;
        public string Code { get; protected set; }
        protected CPF()
        {

        }
        public CPF(string cpf)
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
            while (cpf.Length < ValueMaxCpf)
                cpf = "0" + cpf;
            return cpf;
        }

        public static bool IsValid(string cpf)
        {
            cpf = String.Join("", cpf.Where(Char.IsDigit));
            if (cpf.Length < ValueMaxCpf)
                return false;

            while (cpf.Length < ValueMaxCpf)
                cpf = "0" + cpf;

            var equal = true;
            for (int i = 1; i < ValueMaxCpf && equal; i++)
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
                if (!"0".Equals(cpf[ValueMaxCpf - 2].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cpf[ValueMaxCpf - 2].ToString())
                return false;

            sum = 0;
            for (int i = 0; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cpf[i].ToString());

            result = sum % 11;
            if (result < 2)
            {
                if (!"0".Equals(cpf[ValueMaxCpf - 1].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cpf[ValueMaxCpf - 1].ToString())
                return false;
            return true;
        }

        protected override bool EqualsCore(CPF other)
        {
            return Code.Equals(other.Code);
        }

        protected override int GetHashCodeCore()
        {
            return (GetType().GetHashCode() * 907) ^ Code.GetHashCode();
        }
    }
}
