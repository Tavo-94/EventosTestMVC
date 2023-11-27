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
            ViewBag.CodigoVestimentaList = new SelectList(_context.CodigoVestimentas, "Id", "Nombre");
            ViewBag.TipoEventoList = new SelectList(_context.TipoEventos, "Id", "Nombre");
            return View();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Evento evento)
        {
            
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = evento.Id });
           
            ViewBag.CodigoVestimentaList = new SelectList(_context.CodigoVestimentas, "Id", "Nombre", evento.CodigoVestimentaId);
            ViewBag.TipoEventoList = new SelectList(_context.TipoEventos, "Id", "Nombre", evento.TipoEventoId);
            return RedirectToAction("Index","Home") ;
        }

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
            ViewData["CodigoVestimentaId"] = new SelectList(_context.CodigoVestimentas, "Id", "Id", evento.CodigoVestimentaId);
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
            ViewData["CodigoVestimentaId"] = new SelectList(_context.CodigoVestimentas, "Id", "Id", evento.CodigoVestimentaId);
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
        public async Task<IActionResult> Listas(int id, string tipo, [Bind("Descripcion")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                var eventos = await _context.Eventos.FindAsync(id);

                if (evento == null)
                {
                    return NotFound();
                }

                switch (tipo)
                {
                    case "tarea":
                        var tarea = new Tarea { Descripcion = evento.Descripcion, EventoId = id };
                        _context.Tareas.Add(tarea);
                        break;

                    case "compra":
                        var compra = new Compra { Descripcion = evento.Descripcion, EventoId = id };
                        _context.Compras.Add(compra);
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
