using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PROYECTO2PARCIAL;Integrated Security=True;TrustServerCertificate=True;");
        //}
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<SolicitudSoporte> SolicitudSoportes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Solicitud> SolicitudPedido { get; set; }
        public DbSet<Orden> Orden { get; set; }


    }
}
