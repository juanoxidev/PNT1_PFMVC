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
    public class CPValidationAttribute : RegularExpressionAttribute
    {
        private const string CPPattern = @"^\d{4}$"; //@"^\d{7,10}$" son expresiones regulares

        public CPValidationAttribute() : base(CPPattern) //contenga solo dígitos y tenga una longitud mínima de 7 y máxima de 10 caracteres
        {
            ErrorMessage = "Ingrese un codPostal válido";
        }

        public override bool IsValid(object value)// Verificar que no contenga puntos ni caracteres especiales
        {
            if (value is string cp)
            {

                if (Regex.IsMatch(cp, @"^[0-9]+$")) //Utilizamos @"^[0-9]+$" para comprobar que el DNI esté compuesto únicamente por dígitos
                {
                    return base.IsValid(value);
                }
            }

            return false;
        }
    }
}
