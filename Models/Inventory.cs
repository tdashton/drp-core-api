namespace DRP_API.Models;

public enum InventoryUnit { Meter=1, Count=0 };

public class Inventory {
    public int Id { get; set; }
    public string? Name { get; set; }
    public InventoryUnit Unit { get; set; }
    public string? Description { get; set; }
}
