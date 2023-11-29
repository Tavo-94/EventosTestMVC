using EventosTestMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventosTestMVC.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //continuar implementando
        //falta cargar un evento en la DB y traerlo
        [HttpPost]
        public IActionResult DetalleEvento(string GuidDeEvento)
        {
            var Guid = new Guid(GuidDeEvento);
            return View();
        }

        public IActionResult CrearNuevoEvento()
        {

            return View("NuevoEventoForm", new EventoEntity());
        }
    }
}
