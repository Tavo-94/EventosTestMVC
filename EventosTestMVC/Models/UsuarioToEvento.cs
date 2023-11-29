using System.ComponentModel.DataAnnotations;

namespace EventosTestMVC.Models
{
    public class UsuarioToEvento
    {
        [Key]
        public int Id { get; set; }
        public string UsuarioEmail { get; set; }
        public Guid EventoId { get; set; }

        //Planner o invitado
        public string Rol { get; set; }

        public UsuarioEntity Usuario { get; set; }
        public EventoEntity Evento { get; set; }
    }
}
