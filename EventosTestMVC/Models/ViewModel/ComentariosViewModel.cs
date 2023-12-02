namespace EventosTestMVC.Models.ViewModel
{
    public class ComentariosViewModel
    {
        public EventoEntity Evento { get; set; }
        public string UserEmail { get; set; }
        public UserComment Comentario { get; set; }
    }
}
