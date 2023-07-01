using DeliveryApp.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Pedido
    { // definimos las propiedades / campos en sql server
        [Key] // primarykey using System.ComponentModel.DataAnnotations; 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // que se autoincremente el id
        public int IdPedido { get; set; }
        [Required(ErrorMessage ="Debe seleccionar una fecha")]
        [DataType(DataType.DateTime)]
        [FechaActual(ErrorMessage = "La fecha del pedido debe ser igual o posterior a la fecha actual.")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        [Display(Name = "Fecha del pedido")]
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
        [Required(ErrorMessage = "Debe ingresar un precio para el pedido")]
        [DataType(DataType.Currency, ErrorMessage ="Debe ingresar un precio para el pedido")]
        [Range(0, 9999999)]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una forma de envio")]
        [Display(Name = "Forma de envió")]
        public Envio FormaEnvio { get; set; }
    }
}
