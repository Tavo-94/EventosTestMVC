namespace EventosTestMVC.Models
{
    public class Invitado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
