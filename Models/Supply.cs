using System.Text.Json.Serialization;
namespace DRP_API.Models;

public class Supply
{
    public int Id { get; set; }
    public string? Info { get; set; }
    public decimal Cost { get; set; }
    public int Amount { get; set; }
    public int InventoryId { get; set; } // Required foreign key property

    [JsonIgnore]
    public Inventory? Inventory { get; set; } = null!; // Required reference navigation to principal
}
