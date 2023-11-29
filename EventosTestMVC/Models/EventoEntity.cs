namespace EventosTestMVC.Models
{
    public class EventoEntity
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeEvento { get; set; }

        public ICollection<UsuarioEntity> Usuarios { get; set; }
        public ICollection<UsuarioToEvento> UsuarioToEventos { get; set; }

        //nav comments
        public ICollection<UserComment> UserComments { get; set; }

        //nav props for tags relation m to m
        public ICollection<Tag> Tags { get; set; }
        public ICollection<TagsToEvent> TagEvents { get; set; }

        //nav props for Supply

        public ICollection<Supply> Supplies { get; set; }
    }
}
