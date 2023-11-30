namespace EventosTestMVC.Models
{
    public class CompraEntity
    {
        public int Id { get; set; } // Clave primaria
        public string Descripcion { get; set; }

        // Clave foránea
        public int EventoId { get; set; }
        public EventoEntity Evento { get; set; }
    }
}