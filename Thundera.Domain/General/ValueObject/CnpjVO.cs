using System;
using System.Linq;
using Thundera.Domain.Core.Models;

namespace Thundera.Domain.General.ValueObject
{
    public class CnpjVO : ValueObject<CnpjVO>
    {
        public const int LengthMaxCnpj = 14;
        public string Code { get; protected set; }
        protected CnpjVO()
        {
        }
        public CnpjVO(string cnpj)
        {
            Code = cnpj;
        }
        protected override bool EqualsCore(CnpjVO other)
        {
            return Code.Equals(other.Code);
        }

        protected override int GetHashCodeCore()
        {
            return (GetType().GetHashCode() * 907) ^ Code.GetHashCode();
        }

        public string GetCnpjFull()
        {
            var cnpj = Code;
            if (string.IsNullOrEmpty(cnpj))
                return "";
            while (cnpj.Length < LengthMaxCnpj)
                cnpj = "0" + cnpj;
            return cnpj;
        }

        public static string GetCnpjClean(string cnpj)
        {
            cnpj = String.Join("", cnpj.Where(Char.IsDigit));
            if (string.IsNullOrEmpty(cnpj))
                return "";
            while (cnpj.StartsWith("0"))
                cnpj = cnpj.Substring(1);
            return cnpj;
        }

        public static bool IsValid(string cnpj)
        {
            cnpj = String.Join("", cnpj.Where(Char.IsDigit));
            if (cnpj.Length < LengthMaxCnpj)
                return false;

            while (cnpj.Length < LengthMaxCnpj)
                cnpj = "0" + cnpj;

            var baseNumbers = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum = 0;
            for (int i = 1; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cnpj[i - 1].ToString());

            var result = sum % 11;

            if (result < 2)
            {
                if (!"0".Equals(cnpj[LengthMaxCnpj - 2].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cnpj[LengthMaxCnpj - 2].ToString())
                return false;

            sum = 0;
            for (int i = 0; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cnpj[i].ToString());

            result = sum % 11;
            if (result < 2)
            {
                if (!"0".Equals(cnpj[LengthMaxCnpj - 1].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cnpj[LengthMaxCnpj - 1].ToString())
                return false;
            return true;
        }
    }
}
