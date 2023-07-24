namespace DRP_API.Models;

using Microsoft.EntityFrameworkCore;

public class CoreApiContext : DbContext
{
    public CoreApiContext(DbContextOptions<CoreApiContext> options) : base(options)
    {
    }

    public DbSet<Inventory> TodoItems { get; set; } = null!;
}
