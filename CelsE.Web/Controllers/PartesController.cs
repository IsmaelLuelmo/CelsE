namespace CelsE.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using CelsE.Web.Data;
    using CelsE.Web.Data.Entity;
    using Microsoft.AspNetCore.Authorization;

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
            return View(await _context.Parte.ToListAsync());
        }

        // GET: Partes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parteEntity = await _context.Parte
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parteEntity == null)
            {
                return NotFound();
            }

            return View(parteEntity);
        }

        // GET: Partes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FechaInicio,Observaciones,MedidasAdoptadas")] ParteEntity parteEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parteEntity);
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
            return View(parteEntity);
        }

        // POST: Partes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FechaInicio,Observaciones,MedidasAdoptadas")] ParteEntity parteEntity)
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
