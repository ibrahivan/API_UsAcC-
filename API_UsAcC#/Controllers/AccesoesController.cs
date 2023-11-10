using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_UsAcC_;
using API_UsAcC_.Models;

namespace API_UsAcC_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoesController : ControllerBase
    {
        private readonly Contexto _context;

        public AccesoesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Accesoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acceso>>> Getaccesos()
        {
          if (_context.accesos == null)
          {
              return NotFound();
          }
            return await _context.accesos.ToListAsync();
        }

        // GET: api/Accesoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acceso>> GetAcceso(long id)
        {
          if (_context.accesos == null)
          {
              return NotFound();
          }
            var acceso = await _context.accesos.FindAsync(id);

            if (acceso == null)
            {
                return NotFound();
            }

            return acceso;
        }

        // PUT: api/Accesoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(long id, Acceso acceso)
        {
            if (id != acceso.id_acceso)
            {
                return BadRequest();
            }

            _context.Entry(acceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoExists(id))
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

        // POST: api/Accesoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acceso>> PostAcceso(Acceso acceso)
        {
          if (_context.accesos == null)
          {
              return Problem("Entity set 'Contexto.accesos'  is null.");
          }
            _context.accesos.Add(acceso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcceso", new { id = acceso.id_acceso }, acceso);
        }

        // DELETE: api/Accesoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcceso(long id)
        {
            if (_context.accesos == null)
            {
                return NotFound();
            }
            var acceso = await _context.accesos.FindAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }

            _context.accesos.Remove(acceso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccesoExists(long id)
        {
            return (_context.accesos?.Any(e => e.id_acceso == id)).GetValueOrDefault();
        }
    }
}
