using DRP_API.Models;
using DRP_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DRP_API.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase 
{
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Inventory>> GetAll() => InventoryService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Inventory> Get(int id)
    {
        var inventory = InventoryService.Get(id);

        if(inventory == null)
            return NotFound();

        return inventory;
    }

    [HttpPost]
    public ActionResult<Inventory> Create(Inventory inventory)
    {            
        InventoryService.Add(inventory);
        return CreatedAtAction(nameof(Get), new { id = inventory.Id }, inventory);
    }

}
