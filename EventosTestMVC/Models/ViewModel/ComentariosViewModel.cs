namespace EventosTestMVC.Models.ViewModel
{
    public class ComentariosViewModel
    {
        public EventoEntity Evento { get; set; }
        public UsuarioEntity UsuarioLogeado { get; set; }
        public UserComment Comentario { get; set; }
    }
}
