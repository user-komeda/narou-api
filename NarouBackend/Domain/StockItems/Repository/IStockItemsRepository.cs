namespace NarouBackend.Domain.StockItems.Repository;

using Dto;
using Infrastructure.StockItems.Entity;


public interface IStockItemsRepository {
    public Task<StockItemsDto> Create(ApplicationUser applicationUser, StockItemsDto stockItemsDto);
    public Task<StockItemsDto> Delete(int userId, string ncode);
}
