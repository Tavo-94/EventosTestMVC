using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosTest.Data;
using EventosTestMVC.Models;
using Microsoft.AspNetCore.Hosting;

namespace EventosTestMVC.Controllers
{
    public class AvatarsController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AvatarsController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

        public IActionResult SelectAvatar()
        {
            var avatars = _context.Avatares.ToList(); // Reemplaza con tu lógica para obtener la lista de avatares
            return View(avatars);
        }

        // POST: Avatars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArchivoLottieFormFile")] Avatar avatar)
   
            {
            // Guarda el archivo JSON Lottie en la carpeta ~/json
            if (avatar.ArchivoLottieFormFile != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "json");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + avatar.ArchivoLottieFormFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await avatar.ArchivoLottieFormFile.CopyToAsync(fileStream);
                }

                avatar.ArchivoLottie = "/json/" + uniqueFileName;
            }

            _context.Add(avatar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Avatars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Avatares == null)
            {
                return NotFound();
            }

            var avatar = await _context.Avatares.FindAsync(id);
            if (avatar == null)
            {
                return NotFound();
            }
            return View(avatar);
        }

        // POST: Avatars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArchivoLottie")] Avatar avatar)
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
