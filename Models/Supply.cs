namespace DRP_API.Models;

public class Supply
{
    public int Id { get; set; }
    public string? Info { get; set; }
    public decimal Cost { get; set; }
    public int InventoryId { get; set; }
    public int Amount { get; set; }
}
