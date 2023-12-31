namespace DRP_API.Models;

public class Design {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<DesignRequiredInventory> RequiredInventory { get; } = new();
}
