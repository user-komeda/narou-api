namespace NarouBackend.Infrastructure.StockItems.DbContext;

using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityUserContext<ApplicationUser>(options) {
    public DbSet<StockItemsEntity> StockItemsEntity { get; set; }
    public DbSet<ApplicationUser?> applicationUser { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.Entity<StockItemsEntity>().HasIndex(static m => new { m.Ncode, m.UserId }).IsUnique();
    }
}
