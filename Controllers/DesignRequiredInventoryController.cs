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
    [Route("Design/{designId}/[controller]")]
    [ApiController]
    public class DesignRequiredInventoryController : ControllerBase
    {
        private readonly CoreApiContext _context;

        public DesignRequiredInventoryController(CoreApiContext context)
        {
            _context = context;
        }

        // GET: DesignRequiredInventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignRequiredInventory>>> GetDesignRequiredInventory([FromRoute] int DesignId)
        {
            return await _context.DesignRequiredInventory.ToListAsync();
        }

        // GET: DesignRequiredInventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignRequiredInventory>> GetDesignRequiredInventory([FromRoute] int DesignId, int id)
        {
            var designRequiredInventory = await _context.DesignRequiredInventory.FindAsync(id);

            if (designRequiredInventory == null)
            {
                return NotFound();
            }

            return designRequiredInventory;
        }

        // PUT: DesignRequiredInventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignRequiredInventory([FromRoute] int DesignId, int id, DesignRequiredInventory designRequiredInventory)
        {
            if (id != designRequiredInventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(designRequiredInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignRequiredInventoryExists(id))
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

        // POST: DesignRequiredInventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesignRequiredInventory>> PostDesignRequiredInventory([FromRoute] int DesignId, DesignRequiredInventory designRequiredInventory)
        {
            _context.DesignRequiredInventory.Add(designRequiredInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignRequiredInventory", new { id = designRequiredInventory.Id }, designRequiredInventory);
        }

        // DELETE: DesignRequiredInventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignRequiredInventory([FromRoute] int DesignId, int id)
        {
            var designRequiredInventory = await _context.DesignRequiredInventory.FindAsync(id);
            if (designRequiredInventory == null)
            {
                return NotFound();
            }

            _context.DesignRequiredInventory.Remove(designRequiredInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesignRequiredInventoryExists(int id)
        {
            return _context.DesignRequiredInventory.Any(e => e.Id == id);
        }
    }
}
