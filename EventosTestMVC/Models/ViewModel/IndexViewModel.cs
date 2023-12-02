namespace EventosTestMVC.Models.ViewModel
{
    public class IndexViewModel
    {
        public string GuidDeEvento { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; } = new List<EventoEntity>();

    }
}
