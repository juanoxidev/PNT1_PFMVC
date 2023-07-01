using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Validators
{

    public class FechaActualAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime fechaPedido = (DateTime)value;

            // Verificar si la fecha del pedido es mayor o igual a la fecha de hoy
            if (fechaPedido.Date >= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("La fecha del pedido debe ser igual o posterior a la fecha actual.");
            }
        }
    }
}
