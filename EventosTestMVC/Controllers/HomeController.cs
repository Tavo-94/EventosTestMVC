using EventosTest.Data;
using EventosTestMVC.Models;
using EventosTestMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventosTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataContext _dataContext;


        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;

        }



        public IActionResult Index()
        {

            var model = new IndexViewModel();
            if (HttpContext.Session.GetString("UserLogInId") != null)
            {
                var usuarioId = HttpContext.Session.GetString("UserLogInId");

                model.Eventos = _dataContext.UsuarioToEventos.Where(e => e.UsuarioEmail == usuarioId && e.Rol == "Planner").Select(e => e.Evento).ToList();
            }
            

            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Mesas()
        {
            return View("mesas");

        }

        public IActionResult Listas()
        {
            return View("listas");

        }


        public IActionResult Facturas()
        {
            return View("Facturas");

        }

        public IActionResult Fotos ()
        {
            return View("Fotos");

        }
    }
}