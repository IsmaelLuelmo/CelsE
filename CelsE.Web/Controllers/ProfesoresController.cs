namespace CelsE.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using CelsE.Web.Data;
    using CelsE.Web.Data.Entity;
    using Microsoft.AspNetCore.Authorization.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using System.Collections.Generic;

    [Authorize(Roles = "Admin")]
    public class ProfesoresController : Controller
    {
        private readonly DataContext _context;
        
        public ProfesoresController(DataContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesor.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesorEntity = await _context.Profesor
                .FirstOrDefaultAsync(m => m.ID == id); ;
            if (profesorEntity == null)
            {
                return NotFound();
            }

            var partesAlumno = _context.Parte.Where(m => m.Profesor.ID == id);

            List<string> campo = new List<string>();
            foreach (ParteEntity parte in partesAlumno)
            {
                campo.Add(parte.ID.ToString() + "-" + parte.Observaciones);
            }

            ViewBag.campo = campo;

            return View(profesorEntity);          
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfesorEntity profesorEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Convertimos el DNI en mayúsculas
                    profesorEntity.DNI = profesorEntity.DNI.ToUpper();
                    _context.Add(profesorEntity);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un profesor con ese DNI");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(profesorEntity);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesorEntity = await _context.Profesor.FindAsync(id);
            if (profesorEntity == null)
            {
                return NotFound();
            }
            return View(profesorEntity);
        }

        // POST: Profesores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProfesorEntity profesorEntity)
        {
            if (id != profesorEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesorEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ProfesorEntityExists(profesorEntity.ID))
                    {
                        ModelState.AddModelError(string.Empty, "No existe este DNI");
                    }

                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un profesor con ese DNI");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profesorEntity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProfesorEntity profesorEntity = await _context.Profesor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profesorEntity == null)
            {
                return NotFound();
            }

            _context.Profesor.Remove(profesorEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorEntityExists(int id)
        {
            return _context.Profesor.Any(e => e.ID == id);
        }

        public IActionResult DetailsParte(string value)
        {
            string ID = value.Split('-')[0];
            return RedirectToAction("Details/" + ID, "Partes");
        }
    }
}
