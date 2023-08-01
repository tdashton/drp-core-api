using DRP_API.Models;
using DRP_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DRP_API.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase 
{
    private readonly ILogger<InventoryController> _logger;
    private readonly CoreApiContext _context;

    public InventoryController(
        ILogger<InventoryController> logger,
        CoreApiContext context
    ) {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Inventory>> GetInventory()
    {
        return _context.Inventory.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Inventory>> GetInventory(int id)
    {
        var inv = await _context.Inventory.FindAsync(id);

        if (inv == null)
        {
            return NotFound();
        }

        return inv;
    }

    [HttpPost]
    public async Task<ActionResult<Inventory>> Create(Inventory inventory)
    {
        // Insert Inventory
        _context.Inventory.Add(inventory);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Create), new { id = inventory.Id }, inventory);
    }
}
