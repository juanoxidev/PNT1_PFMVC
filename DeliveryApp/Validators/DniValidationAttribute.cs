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
        private const string DniPattern = @"^\d{7,10}$";

        public DniValidationAttribute() : base(DniPattern) // verifica que el dni tenga una extension de 7 a 10 caracteres
        {
            ErrorMessage = "Ingrese un DNI válido";
        }

        public override bool IsValid(object value)
        {
            if (value is string dni)
            {
                // Verificar que no contenga puntos ni caracteres especiales
                if (Regex.IsMatch(dni, @"^[0-9]+$"))
                {
                    return base.IsValid(value);
                }
            }

            return false;
        }
    }
}
