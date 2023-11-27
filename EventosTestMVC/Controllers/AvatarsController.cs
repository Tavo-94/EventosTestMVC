using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosTest.Data;
using EventosTestMVC.Models;
using System.Diagnostics;

namespace EventosTestMVC.Controllers
{
    public class AvatarsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataContext _context;

        public AvatarsController(IWebHostEnvironment hostingEnvironment, DataContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Avatars
        public async Task<IActionResult> Index()
        {
              return _context.Avatares != null ? 
                          View(await _context.Avatares.ToListAsync()) :
                          Problem("Entity set 'DataContext.Avatares'  is null.");
        }

        // GET: Avatars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Avatares == null)
            {
                return NotFound();
            }

            var avatar = await _context.Avatares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avatar == null)
            {
                return NotFound();
            }

            return View(avatar);
        }

        // GET: Avatars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avatars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ruta")] Avatar avatar, IFormFile archivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (archivo != null && archivo.Length > 0)
                    {
                        var rutaAvatar = Path.Combine(_hostingEnvironment.WebRootPath, "json");

                        if (!Directory.Exists(rutaAvatar))
                        {
                            Directory.CreateDirectory(rutaAvatar);
                        }

                        var nombreArchivo = Path.GetRandomFileName() + Path.GetExtension(archivo.FileName);
                        var rutaCompleta = Path.Combine(rutaAvatar, nombreArchivo);

                        using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                        {
                            await archivo.CopyToAsync(stream);
                        }

                        avatar.Ruta = Path.Combine("json", nombreArchivo);
                    }

                    _context.Add(avatar);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al guardar el archivo: {ex.Message}");
                    throw;
                }
            }

            return View(avatar);
        }

        // POST: Avatars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ruta")] Avatar avatar)
        {
            if (id != avatar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avatar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvatarExists(avatar.Id))
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
            return View(avatar);
        }

        // GET: Avatars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Avatares == null)
            {
                return NotFound();
            }

            var avatar = await _context.Avatares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avatar == null)
            {
                return NotFound();
            }

            return View(avatar);
        }

        // POST: Avatars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Avatares == null)
            {
                return Problem("Entity set 'DataContext.Avatares'  is null.");
            }
            var avatar = await _context.Avatares.FindAsync(id);
            if (avatar != null)
            {
                _context.Avatares.Remove(avatar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvatarExists(int id)
        {
          return (_context.Avatares?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
