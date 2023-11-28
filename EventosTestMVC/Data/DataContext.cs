using EventosTestMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventosTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Invitado> Invitados { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<Avatar> Avatares { get; set; }
        public DbSet<CodigoVestimenta> CodigoVestimenta { get; set; }
        public DbSet<TipoEvento> TipoEventos { get; set; }

    }
}
