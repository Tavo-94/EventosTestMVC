using EventosTest.Data;
using EventosTestMVC.Models;
using EventosTestMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace EventosTestMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View(new LogInViewModel());
        }

        [HttpPost]
        public IActionResult LogIn(LogInViewModel logInViewModel)
        {
            if (_dataContext.UsuarioEntities.Any(u => u.Email == logInViewModel.Email && u.Password == logInViewModel.Password))
            {
                var userlogeado = _dataContext.UsuarioEntities.FirstOrDefault(u => u.Email == logInViewModel.Email);
                HttpContext.Session.SetString("UserLogInId", userlogeado.Email.ToString());
                return RedirectToAction("Index", "Home");
            }

            return View(new LogInViewModel());
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Registrar(RegistroViewModel registroViewModel)
        {
            if (ModelState.IsValid)
            {
                // Configura el ID predeterminado del avatar (en este caso, 9)
                registroViewModel.Usuario.AvatarUserId = 9;

                _dataContext.UsuarioEntities.Add(registroViewModel.Usuario);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            // Si el modelo no es válido, vuelve a la vista con el modelo para mostrar errores
            registroViewModel.Avatares = ObtenerListaAvatares(); // Asegúrate de tener un método para obtener la lista de avatares
            return View(registroViewModel);
        }

        [HttpPost]
        public IActionResult Editar(RegistroViewModel registroViewModel)
        {
            if (ModelState.IsValid)
            {
                _dataContext.UsuarioEntities.Update(registroViewModel.Usuario);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            // Si el modelo no es válido, vuelve a la vista con el modelo para mostrar errores
            registroViewModel.Avatares = ObtenerListaAvatares(); // Asegúrate de tener un método para obtener la lista de avatares
            return View(registroViewModel);
        }

        // Agrega el método para obtener la lista de avatares
        private List<SelectListItem> ObtenerListaAvatares()
        {
            return _dataContext.AvatarUsers
                .Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                })
                .ToList();
        }
    }
}
