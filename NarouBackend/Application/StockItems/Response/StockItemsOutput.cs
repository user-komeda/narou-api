namespace NarouBackend.Application.StockItems.Response;

using Domain;
using Domain.StockItems.Dto;


public sealed class StockItemsOutput(
    string ncode,
    string title,
    string writer,
    string story,
    string keyWord) {

    public string ncode { get; } = ncode;
    public string title { get; } = title;
    public string writer { get; } = writer;
    public string story { get; } = story;
    public string keyWord { get; } = keyWord;
    public static StockItemsOutput Convert(StockItemsDto stockItemsDto) => new(stockItemsDto.ncode,
    stockItemsDto.title,
    stockItemsDto.writer,
    stockItemsDto.story,
    stockItemsDto.keyWord);
}
