namespace EventosTestMVC.Models
{
    public class TagsToEvent
    {
        public int Id { get; set; }
        public Guid EventId { get; set; }
        public int TagId { get; set; }

        //nav props
        public  EventoEntity Evento { get; set; }
        public Tag Tag { get; set; }
    }
}
