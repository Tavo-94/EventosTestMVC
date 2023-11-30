using EventosTest.Data;
using EventosTestMVC.Models;
using EventosTestMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace EventosTestMVC.Controllers
{
    public class EventoController : Controller
    {

        private readonly DataContext _dataContext;

        public EventoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index(Guid idDelEvento)
        {
            var userid = HttpContext.Session.GetString("UserLogInId");
            if (userid == null)
            {
                return RedirectToAction("LogIn", "Usuario");
            }


            if (!_dataContext.EventoEntities.Any(e => e.Id == idDelEvento))
            {
                return RedirectToAction("Index", "Home");

            }

            if (!_dataContext.UsuarioToEventos.Any(e => e.EventoId == idDelEvento && e.UsuarioEmail == userid))
            {
                var nuevoInvitado = new UsuarioToEvento();
                nuevoInvitado.UsuarioEmail = userid;
                nuevoInvitado.EventoId = idDelEvento;
                nuevoInvitado.Rol = "Invitado";

                _dataContext.UsuarioToEventos.Add(nuevoInvitado);
                _dataContext.SaveChanges();
            }

            var evento = _dataContext.UsuarioToEventos.Where(e => e.EventoId == idDelEvento && e.UsuarioEmail == userid)
                .Include(e => e.Evento)
                .ThenInclude(e => e.Supplies)
                .Include(e => e.Evento)
                .ThenInclude(e => e.TipoEvento)
                .Include(e => e.Evento)
                .ThenInclude(e => e.CodigoVestimenta)
                .Include(e => e.Evento)
                .ThenInclude(e => e.UserComments)
                .ThenInclude(e=> e.Usuario)
                .FirstOrDefault();

            var creador = _dataContext.UsuarioToEventos.Where(e => e.EventoId == idDelEvento && e.Rol == "Planner")
                .Include(e => e.Usuario)
                .FirstOrDefault();

            var viewModel = new DetalleEventoViewModel();
            viewModel.Evento = evento.Evento;
            viewModel.Rol = evento.Rol;
            if (HttpContext.Session.GetString("UserLogInId") != null)
            {
                viewModel.UserId = HttpContext.Session.GetString("UserLogInId");

            }
            else
            {
                viewModel.UserId = "vacio";
            }

            HttpContext.Session.SetString("RolEvento", evento.Rol);

            viewModel.Comentario = new UserComment();
            viewModel.Comentarios = evento.Evento.UserComments;
            viewModel.Insumo = new Supply();
            viewModel.CreadorDelEvento = creador.Usuario;
            return View(viewModel);
        }

        //agregar comentario
        public IActionResult InsertarComentario(DetalleEventoViewModel model) {

            var comentario = new UserComment();
            comentario.PublishDate = DateTime.Now;
            comentario.UserEmail = HttpContext.Session.GetString("UserLogInId");
            comentario.EventId = model.Evento.Id;
            comentario.TextComment = model.Comentario.TextComment;
            comentario.Evento = _dataContext.EventoEntities.First(c => c.Id == comentario.EventId);
            comentario.Usuario = _dataContext.UsuarioEntities.First(c => c.Email == comentario.UserEmail);

            _dataContext.Comentarios.Add(comentario);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Evento", new { idDelEvento = comentario.EventId });
        }

        //continuar implementando
        //falta cargar un evento en la DB y traerlo
        [HttpPost]
        public IActionResult DetalleEvento(string GuidDeEvento)
        {
            if (!Guid.TryParse(GuidDeEvento, out _))
            {
                return RedirectToAction("Index", "Home");

            }

            var idEvento = new Guid(GuidDeEvento);

            var evento = _dataContext.UsuarioToEventos.Where(e => e.EventoId == idEvento).Include(e => e.Evento).FirstOrDefault();

            HttpContext.Session.SetString("CodigoEvento", GuidDeEvento);


            return RedirectToAction("Index", "Evento", new { idDelEvento = idEvento });
        }

        public IActionResult CrearNuevoEvento()
        {

            var viewmodel = new CrearEventoViewModel();

            var userid = HttpContext.Session.GetString("UserLogInId");
            if (userid == null)
            {
                return RedirectToAction("LogIn", "Usuario");
            }

            viewmodel.usuarioId = userid;
            viewmodel.CodigoDeVestimenta = _dataContext.CodigoVestimenta.Select(c =>
                new SelectListItem() { 
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }).ToList();

            viewmodel.TipoDeEvento = _dataContext.TipoEventos.Select(c =>
                new SelectListItem()
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }).ToList();
            return View("NuevoEventoForm", viewmodel);
        }

        [HttpPost]
        public IActionResult CrearNuevoEvento(CrearEventoViewModel viewModel)
        {
            viewModel.Evento.FechaDeCreacion = DateTime.Now;

            _dataContext.EventoEntities.Add(viewModel.Evento);
            _dataContext.SaveChanges();


            var idinsertado = viewModel.Evento.Id;
            var modelUsuarioToEventos = new UsuarioToEvento();
            modelUsuarioToEventos.UsuarioEmail = viewModel.usuarioId;
            modelUsuarioToEventos.EventoId = idinsertado;
            modelUsuarioToEventos.Rol = "Planner";
            _dataContext.UsuarioToEventos.Add(modelUsuarioToEventos);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
