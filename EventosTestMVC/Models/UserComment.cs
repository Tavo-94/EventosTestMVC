namespace EventosTestMVC.Models
{
    public class UserComment
    {
        public int Id { get; set; }
        public string TextComment { get; set; }
        public DateTime PublishDate { get; set; }
        public string? UserEmail { get; set; }
        public Guid? EventId { get; set; }


        public UsuarioEntity Usuario { get; set; }
        public EventoEntity Evento { get; set; }
    }
}
