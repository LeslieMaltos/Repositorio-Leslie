using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TiendaFinal.Models;

namespace TiendaFinal.DAL
{
    public class TiendaDeMascotasContext : DbContext
    {
        public TiendaDeMascotasContext() : base("TiendaDeMascotasContext")
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Perro> Perros { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}