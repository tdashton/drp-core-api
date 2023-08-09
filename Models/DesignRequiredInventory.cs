using System.Text.Json.Serialization;
namespace DRP_API.Models;

public class DesignRequiredInventory {
    public int Id { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }

    public int DesignId { get; set; }

    [JsonIgnore]
    public Design? Design { get; }
}
