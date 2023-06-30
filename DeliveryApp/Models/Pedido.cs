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

        [Display(Name = "Fecha del pedido")]
        public DateTime FechaPedido { get; set; }

        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }

        [Display(Name = "Producto")]
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Cliente")]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
    }
}
