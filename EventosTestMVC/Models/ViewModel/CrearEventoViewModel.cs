using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventosTestMVC.Models.ViewModel
{
    public class CrearEventoViewModel
    {
        public EventoEntity Evento { get; set; }
        public string usuarioId { get; set; }
    }
}
