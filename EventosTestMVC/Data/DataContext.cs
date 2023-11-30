using EventosTestMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        //Entidades 2.0
        public DbSet<UsuarioEntity> UsuarioEntities { get; set; }
        public DbSet<EventoEntity> EventoEntities { get; set; }
        public DbSet<UsuarioToEvento> UsuarioToEventos { get; set; }

        public DbSet<AvatarUser> AvatarUsers { get; set; }
        public DbSet<Category> Categorias { get; set; }
        public DbSet<Supply> Insumos { get; set; }
        public DbSet<Tag> Etiquetas { get; set; }
        public DbSet<TagsToEvent> TagsToEvents { get; set; }
        public DbSet<UserComment> Comentarios { get; set; }
        public DbSet<CodigoVestimenta> CodigoVestimenta { get; set; }

        public DbSet<TipoEvento> TipoEventos { get; set; }




    }
}
