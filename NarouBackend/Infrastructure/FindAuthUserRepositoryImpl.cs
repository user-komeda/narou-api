namespace NarouBackend.Infrastructure;

using Domain;
using Domain.StockItems.Exception;
using StockItems.DbContext;
using StockItems.Entity;


public sealed class FindAuthUserRepositoryImpl(AppDbContext dbContext) : IFindAuthUserRepository {
    public async Task<ApplicationUser> Find(string userId) {
        var applicationUser = await dbContext.applicationUser.FindAsync(userId);
        if (applicationUser == null){
            throw new UserNotFoundException();
        }
        return applicationUser;
    }
}
