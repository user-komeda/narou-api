namespace NarouBackend.Domain.StockItems.Service;

using Dto;
using Infrastructure.StockItems.Entity;
using Repository;


public sealed class StockItemsService(IStockItemsRepository stockItemsRepository)
    : IStockItemsService {
    public async Task<StockItemsDto> Create(
        ApplicationUser applicationUser, StockItemsDto stockItemsDto) {
        var createdStockItems =
            await stockItemsRepository.Create(applicationUser, stockItemsDto);
        return createdStockItems;
    }
    public Task<StockItemsDto> Delete(int userId, string ncode) =>
        throw new NotImplementedException();
}
