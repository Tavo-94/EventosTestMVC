namespace EventosTestMVC.Models
{
    public class CodigoVestimenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<EventoEntity> Eventos { get; set; }
    }
}
