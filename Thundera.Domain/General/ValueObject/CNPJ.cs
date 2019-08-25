using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thundera.Domain.Core.Models;

namespace Thundera.Domain.General.ValueObject
{
    public class CNPJ : ValueObject<CNPJ>
    {
        public const int ValueMaxCnpj = 14;
        public string Code { get; protected set; }
        protected CNPJ()
        {
        }
        public CNPJ(string cnpj)
        {
            Code = cnpj;
        }
        protected override bool EqualsCore(CNPJ other)
        {
            return Code.Equals(other.Code);
        }

        protected override int GetHashCodeCore()
        {
            return (GetType().GetHashCode() * 907) + Code.GetHashCode();
        }

        public string GetCnpjFull()
        {
            var cnpj = Code;
            if (string.IsNullOrEmpty(cnpj))
                return "";
            while (cnpj.Length < ValueMaxCnpj)
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
            if (cnpj.Length < ValueMaxCnpj)
                return false;

            while (cnpj.Length < ValueMaxCnpj)
                cnpj = "0" + cnpj;

            var baseNumbers = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum = 0;
            for (int i = 1; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cnpj[i - 1].ToString());

            var result = sum % 11;

            if (result < 2)
            {
                if (!"0".Equals(cnpj[ValueMaxCnpj - 2].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cnpj[ValueMaxCnpj - 2].ToString())
                return false;

            sum = 0;
            for (int i = 0; i < baseNumbers.Count(); i++)
                sum += baseNumbers[i] * int.Parse(cnpj[i].ToString());

            result = sum % 11;
            if (result < 2)
            {
                if (!"0".Equals(cnpj[ValueMaxCnpj - 1].ToString()))
                    return false;
            }
            else if ((11 - result).ToString() != cnpj[ValueMaxCnpj - 1].ToString())
                return false;
            return true;
        }
    }
}
