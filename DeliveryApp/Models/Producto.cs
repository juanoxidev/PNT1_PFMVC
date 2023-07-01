using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Producto
    { // definimos las propiedades / campos en sql server
        [Key] // primarykey using System.ComponentModel.DataAnnotations; 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // que se autoincremente el id
        public int IdProducto { get; set;}
        public string Descripcion { get; set;}
        public float Precio { get; set; }
      

    }
}
