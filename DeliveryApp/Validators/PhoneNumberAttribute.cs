using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

//En este ejemplo, hemos creado la clase PhoneNumberAttribute que hereda de ValidationAttribute. En el método IsValid, verificamos si el 
//valor proporcionado es una cadena y luego utilizamos la expresión regular @"^\d{10}$" para asegurarnos de que tenga exactamente 10 dígitos y solo contenga números
//
namespace DeliveryApp.Validators
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        private const string PhoneNumberPattern = @"^\d{10}$";

        public override bool IsValid(object value) //El método "IsValid" es un método sobrescrito de la clase base "ValidationAttribute"
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
