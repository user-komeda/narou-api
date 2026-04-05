namespace NarouBackend.Application.StockItems.Request;

using Bunit;
using FluentAssertions;
using Domain.StockItems.Dto;
using Xunit;


public sealed class StockItemsInputTests : BunitContext {
    [Fact] public void ShouldConvertStockItemsInputToStockItemsDto() {
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var stockItemsInput = new StockItemsInput("ncode", "title", "writer", "story", "keyWord");

        var result = stockItemsInput.Convert();

        result.Should().BeEquivalentTo(stockItemsDto);
    }
}