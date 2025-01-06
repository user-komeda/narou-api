namespace NarouBackend.Application.StockItems.UseCase;

using Bunit;
using Domain;
using Domain.StockItems.Dto;
using Domain.StockItems.Service;
using FluentAssertions;
using Infrastructure.StockItems.Entity;
using Moq;
using Request;
using Response;
using Xunit;


public sealed class StockItemsCreateUseCaseTests : TestContext {
    [Fact] public async Task ShouldCreateItem() {
        var userId = "965df755-9105-4f30-82e6-06888cba1142";
        var applicationUser = new ApplicationUser();
        var stockItemsOutput = new StockItemsOutput("ncode", "title", "writer", "story", "keyWord");
        var stockItemsInput = new StockItemsInput("ncode", "title", "writer", "story", "keyWord");
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var mockStockItemsService = new Mock<IStockItemsService>();
        var mockFindAuthUserRepository = new Mock<IFindAuthUserRepository>();
        mockFindAuthUserRepository.Setup(v => v.Find(userId)).ReturnsAsync(applicationUser);
        mockStockItemsService.Setup(v => v.Create(applicationUser, It.IsAny<StockItemsDto>()))
            .ReturnsAsync(stockItemsDto);
        Services.AddTransient<IStockItemsService, StockItemsService>();

        var stockItemsCreateUseCase = new StockItemsCreateUseCase(mockStockItemsService.Object,
        mockFindAuthUserRepository.Object);
        var result = await stockItemsCreateUseCase.Invoke(userId, stockItemsInput);

        mockStockItemsService.Verify(v => v.Create(applicationUser, It.IsAny<StockItemsDto>()),
        Times.Once);
        mockFindAuthUserRepository.Verify(v => v.Find(userId),
        Times.Once);
        result.Should().BeEquivalentTo(stockItemsOutput);
    }
}
