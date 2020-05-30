using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CelsE.Web.Data;
using CelsE.Web.Data.Entity;

namespace CelsE.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartesController : ControllerBase
    {
        private readonly DataContext _context;

        public PartesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Partes
        [HttpGet]
        public IEnumerable<ParteEntity> GetParte()
        {
            return _context.Parte
                .Include(p => p.Alumno)
                .Include(p => p.Profesor);
        }

        // GET: api/Partes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParteEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var parteEntity = await _context.Parte.FindAsync(id);

            var parteEntity = await _context.Parte
                .Include(p => p.Alumno)
                .Include(p => p.Profesor)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (parteEntity == null)
            {
                return NotFound();
                
                /*var parteEntity1 = new ParteEntity
                {
                    Observaciones ="Gola"
                };
                _context.Parte.Add(parteEntity1);
                await _context.SaveChangesAsync();*/
            }

            return Ok(parteEntity);
        }

        // PUT: api/Partes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParteEntity([FromRoute] int id, [FromBody] ParteEntity parteEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parteEntity.ID)
            {
                return BadRequest();
            }

            _context.Entry(parteEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Partes
        [HttpPost]
        public async Task<IActionResult> PostParteEntity([FromBody] ParteEntity parteEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Parte.Add(parteEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParteEntity", new { id = parteEntity.ID }, parteEntity);
        }

        // DELETE: api/Partes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParteEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parteEntity = await _context.Parte.FindAsync(id);
            if (parteEntity == null)
            {
                return NotFound();
            }

            _context.Parte.Remove(parteEntity);
            await _context.SaveChangesAsync();

            return Ok(parteEntity);
        }

        private bool ParteEntityExists(int id)
        {
            return _context.Parte.Any(e => e.ID == id);
        }
    }
}