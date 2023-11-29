using System.ComponentModel.DataAnnotations;

namespace EventosTestMVC.Models
{
    public class UsuarioEntity
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? AvatarUserId { get; set; }

        public AvatarUser AvatarUser { get; set; }

        public ICollection<EventoEntity> Eventos { get; set; }
        public ICollection<UsuarioToEvento> UsuarioToEventos { get; set; }
    }
}
