using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Context
{
    public class CafeSelectoContext : DbContext //cafeselectocontext hereda de la clase de contexto entity framework que es la 
        //que tiene la conexionmas todos los objetos mappeados hacia la bdd 
    {
        public CafeSelectoContext(DbContextOptions<CafeSelectoContext> options) /*pasando parametros al constructor, creando un tipo opciones donde la clase de ese objeto ocpiones va a ser del tipo dbcontexts options al a q le pasamols el tipo de dato CafeSelectoContext */
        : base(options)
        {

        }
        // agregamos las entidades de sql server
        public DbSet<Cliente> Clientes { get; set; } // DBset una entidad una tabla. ese dbset va a ser del tipo cliente.
        public DbSet<Producto> Productos { get; set; } //los get set son properties desde el punto de vista de .net
        public DbSet<Pedido> Pedidos { get; set; }

        
    }
}
