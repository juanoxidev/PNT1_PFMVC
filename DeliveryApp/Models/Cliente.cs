using DeliveryApp.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdCliente { get; set; }
        [Display(Name = "DNI")]
        [DniValidation]
        [Required(ErrorMessage = "Debe ingresar un DNI")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Teléfono")]
        [PhoneNumber(ErrorMessage = "Ingrese un teléfono válido")]
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Email")]
        [EmailAddress(ErrorMessage = "No es una direccion de email válida")]
        public string Email { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe ingresar una Dirección")]
        public string Direccion { get; set; }

    }
}
