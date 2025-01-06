namespace NarouBackend.Infrastructure.StockItems.Entity;

using Microsoft.AspNetCore.Identity;


public sealed class ApplicationUser : IdentityUser {
    public List<StockItemsEntity> stockItemsEntities { get; init; } = [];
}
