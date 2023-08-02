using Microsoft.EntityFrameworkCore;
using DRP_API.Models;
namespace DRP_API.Models;

using Microsoft.EntityFrameworkCore;

public class CoreApiContext : DbContext
{
    public CoreApiContext(DbContextOptions<CoreApiContext> options) : base(options)
    {
    }

    public DbSet<Inventory> Inventory { get; set; } = null!;
    public DbSet<Supply> Supply { get; set; } = null!;
    public DbSet<Design> Design { get; set; } = null!;
    public DbSet<DRP_API.Models.DesignRequiredInventory> DesignRequiredInventory { get; set; }
//    public DbSet<DesignInventory> DesignInventory { get; set; } = null!;
}
