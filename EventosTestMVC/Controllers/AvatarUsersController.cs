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
    public class AvatarUsersController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AvatarUsersController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AvatarUsers
        public async Task<IActionResult> Index()
        {
              return _context.AvatarUsers != null ? 
                          View(await _context.AvatarUsers.ToListAsync()) :
                          Problem("Entity set 'DataContext.AvatarUsers'  is null.");
        }

        // GET: AvatarUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvatarUsers == null)
            {
                return NotFound();
            }

            var avatarUser = await _context.AvatarUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avatarUser == null)
            {
                return NotFound();
            }

            return View(avatarUser);
        }

        // GET: AvatarUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvatarUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArchivoLottie")] AvatarUser avatarUser, IFormFile ArchivoLottieFormFile)
        {
            // Guarda el archivo JSON Lottie en la carpeta ~/json
            if (ArchivoLottieFormFile != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "json");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ArchivoLottieFormFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ArchivoLottieFormFile.CopyToAsync(fileStream);
                }

                avatarUser.ArchivoLottie = "/json/" + uniqueFileName;
            }

            _context.Add(avatarUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SelectAvatar()
        {
            var avatars = _context.AvatarUsers.ToList(); // Reemplaza con tu lógica para obtener la lista de avatares
            return View(avatars);
        }
        // GET: AvatarUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvatarUsers == null)
            {
                return NotFound();
            }

            var avatarUser = await _context.AvatarUsers.FindAsync(id);
            if (avatarUser == null)
            {
                return NotFound();
            }
            return View(avatarUser);
        }

        // POST: AvatarUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArchivoLottie")] AvatarUser avatarUser)
        {
            if (id != avatarUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avatarUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvatarUserExists(avatarUser.Id))
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
            return View(avatarUser);
        }

        // GET: AvatarUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvatarUsers == null)
            {
                return NotFound();
            }

            var avatarUser = await _context.AvatarUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avatarUser == null)
            {
                return NotFound();
            }

            return View(avatarUser);
        }

        // POST: AvatarUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvatarUsers == null)
            {
                return Problem("Entity set 'DataContext.AvatarUsers'  is null.");
            }
            var avatarUser = await _context.AvatarUsers.FindAsync(id);
            if (avatarUser != null)
            {
                _context.AvatarUsers.Remove(avatarUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvatarUserExists(int id)
        {
          return (_context.AvatarUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
