using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Context
{
    public class CafeSelectoContext : DbContext
    {
        public CafeSelectoContext(DbContextOptions<CafeSelectoContext> options) /*pasando parametros al constructor, creando un tipo opciones donde la clase de ese objeto ocpiones va a ser del tipo dbcontexts options al a q le pasamols el tipo de dato CafeSelectoContext */
        : base(options)
        {

        }
        // agregamos las entidades de sql server
        public DbSet<Cliente> Clientes { get; set; } // DBset una entidad una tabla. ese dbset va a ser del tipo cliente.
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


    }
}
