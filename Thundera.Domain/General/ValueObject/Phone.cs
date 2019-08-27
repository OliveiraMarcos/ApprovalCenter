﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using Thundera.Domain.Core.Models;

namespace Thundera.Domain.General.ValueObject
{
    public class Phone : ValueObject<Phone>
    {
        public string DDD { get; protected set; }
        public string Number { get; protected set; }

        public const int ValueMaxDDD = 3;
        public const int ValueMaxNumber = 20;
        protected Phone()
        {

        }
        public Phone(string ddd, string number)
        {
            DDD = ddd;
            Number = number;
        }

        public static string GetCleanPhone(string phone)
        {
            String.Join("", phone.Where(Char.IsDigit));
            if (string.IsNullOrEmpty(phone))
                return "";
            return phone;
        }
        public string GetFormattedPhone()
        {
            return $"({DDD}) {Regex.Replace(Number, @"(\d+)(\d{4})", "$1-$2")}";
        }

        protected override bool EqualsCore(Phone other)
        {
            return DDD.Equals(other.DDD) && Number.Equals(other.Number);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = (GetType().GetHashCode() * 907) ^ DDD.GetHashCode();
                hashCode = (hashCode * 907) ^ Number.GetHashCode();
                return hashCode;
            }
        }

        public string GetFullPhone()
        {
            return DDD + Number;
        }
    }
}
