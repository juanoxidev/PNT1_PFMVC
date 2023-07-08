using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace DeliveryApp.Validators
{
    public class DniValidationAttribute : RegularExpressionAttribute
    {
        private const string DniPattern = @"^\d{7,10}$"; //@"^\d{7,10}$" son expresiones regulares

        public DniValidationAttribute() : base(DniPattern) //contenga solo dígitos y tenga una longitud mínima de 7 y máxima de 10 caracteres
        {
            ErrorMessage = "Ingrese un DNI válido";
        }

        public override bool IsValid(object value)// Verificar que no contenga puntos ni caracteres especiales
        {
            if (value is string dni)
            {
                
                if (Regex.IsMatch(dni, @"^[0-9]+$")) //Utilizamos @"^[0-9]+$" para comprobar que el DNI esté compuesto únicamente por dígitos
                {
                    return base.IsValid(value);
                }
            }

            return false;
        }
    }
}
