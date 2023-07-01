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

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "No es una direccion de email válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar una dirección")]
        public string Direccion { get; set; }

    }
}
