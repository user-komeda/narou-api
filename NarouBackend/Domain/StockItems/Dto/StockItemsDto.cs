namespace NarouBackend.Domain.StockItems.Dto;

public sealed class StockItemsDto(
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
}
