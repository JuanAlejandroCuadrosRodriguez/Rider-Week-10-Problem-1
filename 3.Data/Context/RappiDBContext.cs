using System.Collections.Specialized;
using _3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Context;

public class RappiDBContext : DbContext
{
    public RappiDBContext()
    {
        
    }
    public RappiDBContext(DbContextOptions<RappiDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=Ju!081204;Database=Rappi",
                serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Client>().ToTable("Client");
        
        builder.Entity<Order>().ToTable("Order");
        
    }
}