using System.Text.Json.Serialization;
namespace DRP_API.Models;

public class Supply
{
    public int Id { get; set; }
    public string? Info { get; set; }
    public float Cost { get; set; }
    public int Amount { get; set; }
    public int InventoryId { get; set; } // Required foreign key property
    public DateTime DateOrdered { get; set; }
    public DateTime DateReceived { get; set; }
  
    [JsonIgnore]
    public Inventory? Inventory { get; set; } = null!; // Required reference navigation to principal
}
