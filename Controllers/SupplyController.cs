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
    [Route("Inventory/{inventoryId}/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly CoreApiContext _context;

        public SupplyController(CoreApiContext context)
        {
            _context = context;
        }

        // GET: Inventory/{id}/Supply
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetInventorySupply([FromRoute] int inventoryId)
        {
            return await _context.Supply.ToListAsync();
        }

        // GET: Inventory/{id}/Supply/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetInventorySupplyId([FromRoute] int inventoryId, int id)
        {
            var inventory = await _context.Inventory.FindAsync(inventoryId);
            var supply = await _context.Supply.FindAsync(id);

            if (supply == null)
            {
                return NotFound();
            }

            if (inventory.Id != supply.InventoryId) {
                return BadRequest();
            }

            return supply;
        }

        // PUT: Inventory/{id}/Supply/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply([FromRoute] int inventoryId, int id, Supply supply)
        {
            var inventory = await _context.Inventory.FindAsync(inventoryId);

            if (inventory.Id != supply.InventoryId) {
                return BadRequest();
            }

            if (id != supply.Id)
            {
                return BadRequest();
            }

            _context.Entry(supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(id))
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

        // POST: Inventory/{id}/Supply
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supply>> PostSupply([FromRoute] int inventoryId, Supply supply)
        {
            var inventory = await _context.Inventory.FindAsync(inventoryId);

            if (inventory.Id != supply.InventoryId) {
                return BadRequest();
            }
           
            _context.Supply.Add(supply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventorySupplyId", new { id = supply.Id, inventoryId = inventoryId }, supply);
        }

        // DELETE: Inventory/{id}/Supply/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply([FromRoute] int inventoryId, int id)
        {
            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }

            _context.Supply.Remove(supply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplyExists(int id)
        {
            return _context.Supply.Any(e => e.Id == id);
        }
    }
}