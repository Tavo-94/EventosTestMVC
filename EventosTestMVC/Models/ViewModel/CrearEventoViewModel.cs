using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventosTestMVC.Models.ViewModel
{
    public class CrearEventoViewModel
    {
        public EventoEntity Evento { get; set; }
        public string usuarioId { get; set; }
        public List<SelectListItem> CodigoDeVestimenta { get; set; }
        public List<SelectListItem> TipoDeEvento { get; set; }

    }
}
