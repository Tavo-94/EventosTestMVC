namespace EventosTestMVC.Models
{
    public class MesaEntity
    {
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        // Clave foránea
        public int EventoId { get; set; }
        public EventoEntity Evento { get; set; }
    }
}