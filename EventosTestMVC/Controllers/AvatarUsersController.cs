// AvatarController.cs
using EventosTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventosTestMVC.Controllers
{
    public class AvatarController : Controller
    {
        private readonly DataContext _dataContext;


        public AvatarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult SeleccionarAvatar(int avatarId)
        {
            return RedirectToAction("Editar", "Usuario", new { avatarId });
        }

    }
}
