namespace NarouBackend.Application.StockItems.Response;

using Bunit;
using FluentAssertions;
using Domain.StockItems.Dto;
using Xunit;


public sealed class StockItemsOutPutTests : BunitContext {
    [Fact] public void ShouldConvertStockItemsDtoToStockItemsOutPut() {
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var stockItemsOutPut = new StockItemsOutput("ncode", "title", "writer", "story", "keyWord");

        var result = StockItemsOutput.Convert(stockItemsDto);

        result.Should().BeEquivalentTo(stockItemsOutPut);
    }
}
