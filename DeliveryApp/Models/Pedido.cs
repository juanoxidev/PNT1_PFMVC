
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DeliveryApp.Validators;

namespace DeliveryApp.Models
{
    public class Pedido
    { // definimos las propiedades / campos en sql server
        [Key] // primarykey using System.ComponentModel.DataAnnotations; 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // que se autoincremente el id
        public int IdPedido { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha del pedido")]
        [Required(ErrorMessage = "Debe seleccionar una fecha")]
        [FechaActual(ErrorMessage = "La fecha del pedido debe ser igual o posterior a la fecha actual.")]
        public DateTime FechaPedido { get; set; }


        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
        
        [Required]
        [Display(Name = "Producto")]
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        
        [Required]
        [Display(Name = "Cliente")]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Debe ingresar un precio para el pedido")]
        [Range(1, 9999999 , ErrorMessage="El precio debe encontrarse dentro del rango $1 - $9999999")]
        public decimal Precio { get; set; }

        [Display(Name = "Forma de envio")]
        [Required(ErrorMessage = "Debe seleccionar una forma de envio")]
        public Envio FormaEnvio { get; set; }
    }
}
