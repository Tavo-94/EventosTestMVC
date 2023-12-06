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
                .Include(e => e.Evento)
                .ThenInclude(e => e.Supplies)
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
            viewModel.EstaConfirmado = evento.EstaConfirmado;
            return View(viewModel);
        }

        //Comentarios
        public IActionResult Comentarios(string eventoId) {

            var eventoIdentificador = new Guid(eventoId);


                
            var model = new ComentariosViewModel();

            model.Comentario = new UserComment();
            model.Evento = _dataContext.EventoEntities.Where(e => e.Id == eventoIdentificador)
                .Include(e => e.UserComments)
                .ThenInclude(c => c.Usuario)
                .ThenInclude(u => u.AvatarUser)
                .FirstOrDefault();

            model.UsuarioLogeado = _dataContext
                .UsuarioEntities
                .Where(u => u.Email == HttpContext.Session.GetString("UserLogInId"))
                .Include(u => u.AvatarUser)
                .FirstOrDefault();

            return View(model);
        }

        [HttpPost]
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
            viewmodel.CodigoDeVestimenta = _dataContext.CodigoVestimentas.Select(c =>
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

        //Insumos
        public IActionResult AgregarInsumo() { 
        
            var model = new AgregarInsumoViewModel();
            model.EventoId = new Guid(HttpContext.Session.GetString("CodigoEvento"));
            model.Supply = new Supply();
            model.Supply.CategoryId = 1;
            return View(model);
        }

        [HttpPost]
        public IActionResult AgregarInsumo(AgregarInsumoViewModel model)
        {
            var eventoID = model.EventoId;

            model.Supply.EventoId = eventoID;
            model.Supply.EventoEntity = _dataContext.EventoEntities.Where(e => e.Id == model.Supply.EventoId).FirstOrDefault();
            model.Supply.Category = _dataContext.Categorias.Where(e => e.Id == model.Supply.CategoryId).FirstOrDefault();

            _dataContext.Insumos.Add(model.Supply);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Evento", new { idDelEvento = model.EventoId });
        }

        public IActionResult EliminarInsumo(int idInsumo) {

            var insumo = _dataContext
                .Insumos
                .Where(i => i.Id == idInsumo)
                .Include(i => i.Category)
                .Include(i => i.EventoEntity)
                .FirstOrDefault();

            _dataContext.Insumos.Remove(insumo);
            _dataContext.SaveChanges();

            var eventoId = new Guid(HttpContext.Session.GetString("CodigoEvento"));

            return RedirectToAction("Index", "Evento", new {idDelEvento = eventoId });

        }


        //EDITAR EVENTO

        public IActionResult Editar(string eventoId) {

            var identificadorDeEvento = new Guid(eventoId);
            var viewmodel = new CrearEventoViewModel();

            var userid = HttpContext.Session.GetString("UserLogInId");

            viewmodel.usuarioId = userid;
            viewmodel.CodigoDeVestimenta = _dataContext.CodigoVestimentas.Select(c =>
                new SelectListItem()
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }).ToList();

            viewmodel.TipoDeEvento = _dataContext.TipoEventos.Select(c =>
                new SelectListItem()
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }).ToList();

            viewmodel.Evento = _dataContext.EventoEntities.Where(e => e.Id == identificadorDeEvento).FirstOrDefault();

            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Editar(CrearEventoViewModel model) {

            _dataContext.EventoEntities.Update(model.Evento);
            _dataContext.SaveChanges();



            return RedirectToAction("Index", "Evento", new { idDelEvento = model.Evento.Id });
        }

        //listar invitados

        public IActionResult ListarInvitados() {

            var invitados = _dataContext
                .UsuarioToEventos
                .Where(e => e.EventoId == new Guid(HttpContext.Session.GetString("CodigoEvento")) && e.Rol == "Invitado")
                .Include(e => e.Usuario)
                .ToList();
            return View(invitados);
        }


        //confirmar asistencia

        public IActionResult ConfirmarAsistencia()
        {

            var modelo = _dataContext
                .UsuarioToEventos
                .Where(e => e.UsuarioEmail == HttpContext.Session.GetString("UserLogInId"))
                .FirstOrDefault();

            modelo.EstaConfirmado = true;

            _dataContext.UsuarioToEventos.Update(modelo);
            _dataContext.SaveChanges();

            var eventoId = new Guid(HttpContext.Session.GetString("CodigoEvento"));

            return RedirectToAction("Index", "Evento", new { idDelEvento = eventoId });
        }

        public IActionResult DeclinarAsistencia() {

            var modelo = _dataContext
                .UsuarioToEventos
                .Where(e => e.UsuarioEmail == HttpContext.Session.GetString("UserLogInId"))
                .FirstOrDefault();

            modelo.EstaConfirmado = false;

            _dataContext.UsuarioToEventos.Update(modelo);
            _dataContext.SaveChanges();

            var eventoId = new Guid(HttpContext.Session.GetString("CodigoEvento"));

            return RedirectToAction("Index", "Evento", new { idDelEvento = eventoId });
        }

    }
}
