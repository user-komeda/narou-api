namespace NarouBackend.Domain.StockItems.Service;

using Dto;
using Infrastructure.StockItems.Entity;


public interface IStockItemsService {
    public Task<StockItemsDto> Create(ApplicationUser applicationUser, StockItemsDto stockItems);
    public Task<StockItemsDto> Delete(int userId, string ncode);
}
