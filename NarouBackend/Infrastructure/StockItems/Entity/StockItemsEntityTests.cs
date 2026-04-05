namespace NarouBackend.Infrastructure.StockItems.Entity;

using Domain.StockItems.Dto;
using FluentAssertions;
using Xunit;


public sealed class StockItemsEntityTests {
    [Fact] public void ShouldConvertStockItemEntityToStockItemDto() {
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var stockItemsEntity = new StockItemsEntity("ncode", "title", "writer", "story", "keyWord") {
            UserId = "965df755-9105-4f30-82e6-06888cba1142",
            user = new ApplicationUser()
        };

        var result = stockItemsEntity.Convert();

        result.Should().BeEquivalentTo(stockItemsDto);
    }

    [Fact] public void ShouldStockItemsEntityBuildFromStockItemDto() {
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var applicationUser = new ApplicationUser { Id = "965df755-9105-4f30-82e6-06888cba1142" };
        var stockItemsEntity =
            new StockItemsEntity("ncode", "title", "writer", "story", "keyWord") {
                UserId = applicationUser.Id,
                user = applicationUser
            };

        var result = StockItemsEntity.Build(stockItemsDto, applicationUser);

        result.Should().BeEquivalentTo(stockItemsEntity);
    }
}