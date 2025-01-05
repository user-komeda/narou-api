namespace NarouBackend.Domain;

using Infrastructure.StockItems.Entity;


public interface IFindAuthUserRepository {
    public Task<ApplicationUser> Find(string userId);
}
