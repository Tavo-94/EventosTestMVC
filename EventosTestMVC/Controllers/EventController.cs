using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosTestMVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using EventosTest.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventosTestMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.VestimentaList = VestimentaList();
            ViewBag.TagsList = TagsList();
            return View();
        }
        public IActionResult Evento()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event model)
        {
            if (ModelState.IsValid)
            {
                // Convierte los datos del formulario a la entidad Event
                var evento = new Event
                {
                   Titulo = model.Titulo,
                   Description = model.Description,
                   CreationDate = model.CreationDate,
                   EventDate = model.EventDate,
                   PlannerEmail = model.PlannerEmail,
                   Lugar = model.Lugar,
                   Vestimenta = model.Vestimenta,
                   ListaCosas = model.ListaCosas,
                 

                };

                try
                {
                    // Agrega el evento a la base de datos
                    _context.Events.Add(evento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "Event");
                }
                catch (Exception ex)
                {
                    // Maneja cualquier error que pueda ocurrir al guardar en la base de datos
                    ModelState.AddModelError(string.Empty, "Error al guardar el evento. Por favor, inténtalo de nuevo.");
                    // Puedes agregar más detalles al registro del error según tus necesidades
                }
            }

            // Si llegamos a este punto, significa que hubo un error en el modelo, volvemos a mostrar el formulario con errores.
            return View(model);
        }
        private SelectList VestimentaList()
        {
            var tiposVestimenta = _context.Vestimenta.ToList(); // Obtén la lista de tipos de vestimenta desde la base de datos
            return new SelectList(tiposVestimenta, "Id", "Tipo"); // Crea un SelectList con la lista de tipos de vestimenta
        }
        private SelectList TagsList()
        {
            var TagsList = _context.Tags.ToList(); // Obtén la lista de tipos de vestimenta desde la base de datos
            return new SelectList(TagsList, "Id", "Description"); // Crea un SelectList con la lista de tipos de vestimenta
        }

    }
}
