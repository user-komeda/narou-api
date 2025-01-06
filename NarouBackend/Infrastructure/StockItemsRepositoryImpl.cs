namespace NarouBackend.Infrastructure;

using Domain.StockItems.Dto;
using Domain.StockItems.Repository;
using Microsoft.EntityFrameworkCore;
using StockItems.DbContext;
using StockItems.Entity;


public sealed class StockItemsRepositoryImpl(DbContext dbContext) : IStockItemsRepository {

    public async Task<StockItemsDto> Create(ApplicationUser applicationUser,
        StockItemsDto stockItemsDto) {
        var createdStockItemsEntity = StockItemsEntity.Build(stockItemsDto, applicationUser);
        applicationUser.stockItemsEntities.Add(createdStockItemsEntity);
        await dbContext.SaveChangesAsync();
        return createdStockItemsEntity.Convert();
    }
    public Task<StockItemsDto> Delete(int userId, string ncode) =>
        throw new NotImplementedException();
}
