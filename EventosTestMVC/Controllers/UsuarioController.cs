﻿using EventosTest.Data;
using EventosTestMVC.Models;
using EventosTestMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            //1 credenciales invalidas, 2 Registro exitoso


            return View(new LogInViewModel());
        }



        [HttpPost]
        public IActionResult LogIn(LogInViewModel logInViewModel)
        {
            if (_dataContext.UsuarioEntities.Any(u => u.Email == logInViewModel.Email && u.Password == logInViewModel.Password)) {

                var userlogeado = _dataContext.UsuarioEntities.FirstOrDefault(u => u.Email == logInViewModel.Email);

                HttpContext.Session.SetString("UserLogInId", userlogeado.Email.ToString());



                return RedirectToAction("Index","Home");
            }


                return View(new LogInViewModel());
        }

        public IActionResult LogOut()
        {

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");



        }


        public IActionResult Registrar()
        {
            RegistroViewModel viewModel = new RegistroViewModel() {
                Usuario = new UsuarioEntity() { },
                Avatares = _dataContext.AvatarUsers.Select(a =>
                        new SelectListItem() {
                            Text = a.ImageUrl,
                            Value = a.Id.ToString()
                        }
                    ).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Registrar(RegistroViewModel registroViewModel)
        {
            UsuarioEntity nuevoUsuario = registroViewModel.Usuario;

            _dataContext.UsuarioEntities.Add(nuevoUsuario);
            _dataContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }



        public IActionResult Editar(string usuarioEmail)
        {
            RegistroViewModel viewModel = new RegistroViewModel()
            {
                Usuario = _dataContext.UsuarioEntities
                .Where(u => u.Email == HttpContext.Session.GetString("UserLogInId"))
                .Include(u => u.AvatarUser)
                .FirstOrDefault(),
                Avatares = _dataContext.AvatarUsers.Select(a =>
                        new SelectListItem()
                        {
                            Text = a.ImageUrl,
                            Value = a.Id.ToString()
                        }
                    ).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(RegistroViewModel registroViewModel)
        {

            UsuarioEntity updateUsuario = registroViewModel.Usuario;

            _dataContext.UsuarioEntities.Update(updateUsuario);
            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
