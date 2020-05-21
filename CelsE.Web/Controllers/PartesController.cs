namespace CelsE.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using CelsE.Web.Data;
    using CelsE.Web.Data.Entity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    [Authorize(Roles = "Admin, Profesores")]
    public class PartesController : Controller
    {
        private readonly DataContext _context;

        public PartesController(DataContext context)
        {
            _context = context;
        }

        // GET: Partes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parte
                .Include(p => p.Alumno)
                .Include(p => p.Profesor)
                .ToListAsync());
        }

        // GET: Partes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parteEntity = await _context.Parte
                .Include(p => p.Alumno)
                .Include(p => p.Profesor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parteEntity == null)
            {
                return NotFound();
            }

            return View(parteEntity);
        }

        // GET: Partes/Create 
        //id es el número ID del alumno
        public async Task<IActionResult> Create(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var alumnoEntity = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alumnoEntity == null)
            {
                return NotFound();
            }

            //Asignamos el alumno al parte
            ViewBag.Nombre = alumnoEntity.Nombre + " " + alumnoEntity.Apellidos;
            ViewBag.DNI = alumnoEntity.DNI;

            return View();
        }

        // POST: Partes/Create de un alumno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParteEntity parteEntity)
        {
            if (ModelState.IsValid)
            {
                //Buscamos el alumno del parte
                var alumnoEntity = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.ID == parteEntity.ID);
                if (alumnoEntity == null)
                {
                    return NotFound();
                }

                //Generamos un nuevo parte
                ParteEntity nuevoParte = new ParteEntity()
                {
                    FechaInicio = parteEntity.FechaInicio,
                    Observaciones = parteEntity.Observaciones,
                    MedidasAdoptadas = parteEntity.MedidasAdoptadas,
                    ComunicacionPadres = parteEntity.ComunicacionPadres,
                    Alumno = alumnoEntity,
                };

                _context.Add(nuevoParte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parteEntity);
        }

        // GET: Partes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parteEntity = await _context.Parte.FindAsync(id);


            if (parteEntity == null)
            {
                return NotFound();
            }

            /*return View(await _context.Parte
                .Include(p => p.Alumno)
                .Include(p => p.Profesor)
                .ToListAsync());*/

            return View(parteEntity);
        }

        // POST: Partes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ParteEntity parteEntity)
        {
            if (id != parteEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parteEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParteEntityExists(parteEntity.ID))
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
            return View(parteEntity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParteEntity parteEntity = await _context.Parte
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parteEntity == null)
            {
                return NotFound();
            }

            _context.Parte.Remove(parteEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /*// GET: Partes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parteEntity = await _context.ParteEntity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parteEntity == null)
            {
                return NotFound();
            }

            return View(parteEntity);
        }

        // POST: Partes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parteEntity = await _context.ParteEntity.FindAsync(id);
            _context.ParteEntity.Remove(parteEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool ParteEntityExists(int id)
        {
            return _context.Parte.Any(e => e.ID == id);
        }
    }
}
