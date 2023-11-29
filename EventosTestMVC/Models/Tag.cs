namespace EventosTestMVC.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //nav props
        public ICollection<EventoEntity> Eventos { get; set; }
        public ICollection<TagsToEvent> TagEvents { get; set; }
    }
}
