using System.ComponentModel.DataAnnotations;

namespace EventosTestMVC.Models
{
    public class MesaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        // Clave foránea
        public int EventoId { get; set; }
        public EventoEntity Evento { get; set; }
    }
}