namespace NarouBackend.Application.StockItems.Request;

using Domain.StockItems.Dto;
using NarouBackend.Domain;


public sealed class StockItemsInput(
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
    public StockItemsDto Convert() => new StockItemsDto(ncode, title, writer, story, keyWord);
}
