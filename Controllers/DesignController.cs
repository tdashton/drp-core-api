using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRP_API.Models;

namespace DRP_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        private readonly CoreApiContext _context;

        public DesignController(CoreApiContext context)
        {
            _context = context;
        }

        // GET: Design
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Design>>> GetDesign()
        {
            return await _context.Design.ToListAsync();
        }

        // GET: Design/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Design>> GetDesign(int id)
        {
            var design = await _context.Design.FindAsync(id);

            if (design == null)
            {
                return NotFound();
            }

            return design;
        }

        // PUT: Design/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesign(int id, Design design)
        {
            if (id != design.Id)
            {
                return BadRequest();
            }

            _context.Entry(design).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignExists(id))
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

        // POST: Design
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Design>> PostDesign(Design design)
        {
            _context.Design.Add(design);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesign", new { id = design.Id }, design);
        }

        // DELETE: Design/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesign(int id)
        {
            var design = await _context.Design.FindAsync(id);
            if (design == null)
            {
                return NotFound();
            }

            _context.Design.Remove(design);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesignExists(int id)
        {
            return _context.Design.Any(e => e.Id == id);
        }
    }
}
