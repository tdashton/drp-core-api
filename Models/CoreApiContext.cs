namespace DRP_API.Models;

using Microsoft.EntityFrameworkCore;

public class CoreApiContext : DbContext, ICoreApiContext
{
  public CoreApiContext(DbContextOptions<CoreApiContext> options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Inventory>()
        .HasMany(e => e.Supply)
        .WithOne(e => e.Inventory)
        .HasForeignKey(e => e.InventoryId)
        .IsRequired();

    modelBuilder.Entity<Design>()
        .HasMany(e => e.RequiredInventory)
        .WithOne(e => e.Design)
        .HasForeignKey(e => e.DesignId)
        .IsRequired();
  }

  public DbSet<Inventory> Inventory { get; set; } = null!;
  public DbSet<Supply> Supply { get; set; } = null!;
  public DbSet<Design> Design { get; set; } = null!;
  public DbSet<DesignRequiredInventory> DesignRequiredInventory { get; set; } = null!;
}
