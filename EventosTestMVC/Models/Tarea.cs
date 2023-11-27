namespace EventosTestMVC.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
