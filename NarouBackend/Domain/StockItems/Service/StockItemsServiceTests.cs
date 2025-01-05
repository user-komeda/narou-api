namespace NarouBackend.Domain.StockItems.Service;

using Bunit;
using Dto;
using FluentAssertions;
using Infrastructure;
using Infrastructure.StockItems.Entity;
using Moq;
using Repository;
using Xunit;


public sealed class StockItemsServiceTests : TestContext {
    [Fact] public async Task ShouldCreateStockItem() {
        var applicationUser = new ApplicationUser();
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var mockStockItemsRepository = new Mock<IStockItemsRepository>();
        mockStockItemsRepository.Setup(v => v.Create(applicationUser, stockItemsDto))
            .ReturnsAsync(stockItemsDto);
        Services.AddTransient<IStockItemsRepository, StockItemsRepositoryImpl>();

        var stockItemsService = new StockItemsService(mockStockItemsRepository.Object);
        var result = await stockItemsService.Create(applicationUser, stockItemsDto);

        result.Should().BeEquivalentTo(stockItemsDto);
    }
}
