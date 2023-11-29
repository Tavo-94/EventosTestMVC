using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosTest.Data;
using EventosTestMVC.Models;

namespace EventosTestMVC.Controllers
{
    public class EventosController : Controller
    {
        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;
        }

        //Usuario deprueba
        private async Task<int> CrearUsuarioTemporal()
        {
            var usuarioTemporal = new Usuario
            {
                Nombre = "UsuarioTemporal",
                Apellido = "ApellidoTemporal",
                Email = "temporal@example.com",
                Contraseña = "ContraseñaTemporal",
                AvatarId = 1 // Reemplaza con el ID del avatar que deseas asignar
            };

            _context.Usuarios.Add(usuarioTemporal);
            await _context.SaveChangesAsync();

            return usuarioTemporal.Id;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Eventos.Include(e => e.CodigoVestimenta).Include(e => e.CreadorEvento).Include(e => e.TipoEvento);
            return View(await dataContext.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.CodigoVestimenta)
                .Include(e => e.CreadorEvento)
                .Include(e => e.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            ViewBag.CodigoVestimentaList = new SelectList(_context.CodigoVestimenta, "Id", "Nombre");
            ViewBag.TipoEventoList = new SelectList(_context.TipoEventos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Hora,Lugar,Descripcion,ListaCosasLlevar,Clave,UsuarioId,TipoEventoId,CodigoVestimentaId")] Evento evento)
        {
            // Hardcodear el valor para propósitos de prueba
            evento.UsuarioId = 2; // Reemplaza con el ID de usuario que deseas usar

            _context.Add(evento);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = evento.Id });
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Hora,Lugar,Descripcion,ListaCosasLlevar,Clave,UsuarioId,TipoEventoId,CodigoVestimentaId")] Evento evento)
        //{
        //    // Hardcodear el valor para propósitos de prueba
        //    evento.UsuarioId = 1; // Reemplaza con el ID de usuario que deseas usar

        //    _context.Add(evento);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Details", new { id = evento.Id });

        //    ViewBag.CodigoVestimentaList = new SelectList(_context.CodigoVestimenta, "Id", "Nombre", evento.CodigoVestimentaId);
        //    ViewBag.TipoEventoList = new SelectList(_context.TipoEventos, "Id", "Nombre", evento.TipoEventoId);
        //    return RedirectToAction("Details","Eventos") ;
        //}

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["CodigoVestimentaId"] = new SelectList(_context.CodigoVestimenta, "Id", "Id", evento.CodigoVestimentaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", evento.UsuarioId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEventos, "Id", "Id", evento.TipoEventoId);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Hora,Lugar,Descripcion,ListaCosasLlevar,Clave,UsuarioId,TipoEventoId,CodigoVestimentaId")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoVestimentaId"] = new SelectList(_context.CodigoVestimenta, "Id", "Id", evento.CodigoVestimentaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", evento.UsuarioId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEventos, "Id", "Id", evento.TipoEventoId);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.CodigoVestimenta)
                .Include(e => e.CreadorEvento)
                .Include(e => e.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eventos == null)
            {
                return Problem("Entity set 'DataContext.Eventos'  is null.");
            }
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
          return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Listas(int id, string tipo, [Bind("Descripcion")] Tarea tarea, Compra compra)
        {
            if (ModelState.IsValid)
            {
                var eventos = await _context.Eventos.FindAsync(id);

                if (tarea == null && compra == null)
                {
                    return NotFound();
                }

                switch (tipo)
                {
                    case "tarea":
                        var tareas = new Tarea { Descripcion = tarea.Descripcion, EventoId = id };
                        _context.Tareas.Add(tareas);
                        break;

                    case "compra":
                        var compras = new Compra { Descripcion = compra.Descripcion, EventoId = id };
                        _context.Compras.Add(compras);
                        break;

                    default:
                        // Tipo no reconocido
                        return BadRequest();
                }

                await _context.SaveChangesAsync();

                return View("Listas");
            }

            return View("Listas");
        }
    }
}
