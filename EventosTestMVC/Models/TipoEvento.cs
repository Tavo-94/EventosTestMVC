namespace EventosTestMVC.Models
{
    public class TipoEvento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<EventoEntity> Eventos { get; set; }
    }
}
