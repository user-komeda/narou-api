namespace NarouBackend.Infrastructure.StockItems.Entity;

using Domain.StockItems.Dto;
using FluentAssertions;
using Xunit;


public sealed class StockItemsEntityTests {
    [Fact] public void ShouldConvertStockItemEntityToStockItemDto() {
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var stockItemsEntity = new StockItemsEntity("ncode", "title", "writer", "story", "keyWord");

        var result = stockItemsEntity.Convert();

        result.Should().BeEquivalentTo(stockItemsDto);
    }
    [Fact] public void ShouldStockItemsEntityBuildFromStockItemDto() {
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var stockItemsEntity =
            new StockItemsEntity("ncode", "title", "writer", "story", "keyWord");

        var result = StockItemsEntity.Build(stockItemsDto, new ApplicationUser());

        result.Should().BeEquivalentTo(stockItemsEntity);
    }
}
