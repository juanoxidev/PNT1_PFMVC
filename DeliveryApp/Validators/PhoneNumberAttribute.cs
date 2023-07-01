using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliveryApp.Validators
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        private const string PhoneNumberPattern = @"^\d{10}$";

        public override bool IsValid(object value)
        {
            if (value is string phoneNumber)
            {
                // Verificar que el número de teléfono tenga 10 dígitos y solo contenga números
                if (Regex.IsMatch(phoneNumber, PhoneNumberPattern))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
