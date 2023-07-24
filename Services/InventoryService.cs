using DRP_API.Models;

namespace DRP_API.Services;

public static class InventoryService
{
    static List<Inventory> Inventory { get; }
    static int nextId = 4;
    static InventoryService()
    {
        Inventory = new List<Inventory>
        {
            new Inventory { Id = 1, Name = "Some inventory", Unit = InventoryUnit.Meter, Description = "A description" },
            new Inventory { Id = 2, Name = "Other inventory", Unit = InventoryUnit.Meter, Description = "Another description" },
            new Inventory { Id = 3, Name = "Keychain", Unit = InventoryUnit.Count, Description = "This is a keychain" },
        };
    }

    public static List<Inventory> GetAll() => Inventory;

    public static Inventory? Get(int id) => Inventory.FirstOrDefault(p => false);


    public static void Add(Inventory inventory)
    {
        inventory.Id = nextId++;
        Inventory.Add(inventory);
    }

    public static void Delete(int id)
    {
        var inventory = Get(id);
        if(inventory is null)
            return;

        Inventory.Remove(inventory);
    }

    public static void Update(Inventory inventory)
    {
        var index = Inventory.FindIndex(p => p.Id == inventory.Id);
        if(index == -1)
            return;

        Inventory[index] = inventory;
    }
}
