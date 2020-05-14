namespace CelsE.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using CelsE.Web.Data;
    using CelsE.Web.Data.Entity;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin, Profesores")]
    public class AlumnosController : Controller
    {
        private readonly DataContext _context;

        public AlumnosController(DataContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnoEntity = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alumnoEntity == null)
            {
                return NotFound();
            }

            return View(alumnoEntity);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlumnoEntity alumnoEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Convertimos el DNI en mayúsculas
                    alumnoEntity.DNI = alumnoEntity.DNI.ToUpper();
                    _context.Add(alumnoEntity);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un alumno con ese DNI");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(alumnoEntity);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnoEntity = await _context.Alumnos.FindAsync(id);
            if (alumnoEntity == null)
            {
                return NotFound();
            }
            return View(alumnoEntity);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlumnoEntity alumnoEntity)
        {
            if (id != alumnoEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!AlumnoEntityExists(alumnoEntity.ID))
                    {
                        ModelState.AddModelError(string.Empty, "No existe este DNI");
                    }

                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un alumno con ese DNI");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alumnoEntity);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AlumnoEntity alumnosEntity = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alumnosEntity == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumnosEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Alumnos/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnoEntity = await _context.alumnos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alumnoEntity == null)
            {
                return NotFound();
            }

            return View(alumnoEntity);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnoEntity = await _context.alumnos.FindAsync(id);
            _context.alumnos.Remove(alumnoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool AlumnoEntityExists(int id)
        {
            return _context.Alumnos.Any(e => e.ID == id);
        }
    }
}
