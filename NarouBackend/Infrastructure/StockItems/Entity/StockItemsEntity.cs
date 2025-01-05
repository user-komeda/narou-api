namespace NarouBackend.Infrastructure.StockItems.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NarouBackend.Domain.StockItems.Dto;


public sealed class StockItemsEntity(
    string ncode,
    string title,
    string writer,
    string story,
    string keyWord) {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [Key] public int Id { get; set; }
    public string Ncode { get; set; } = ncode;
    public string Title { get; set; } = title;
    public string Writer { get; set; } = writer;
    public string Story { get; set; } = story;
    public string KeyWord { get; set; } = keyWord;

    public string UserId { get; set; }
    public ApplicationUser user { get; set; }

    public static StockItemsEntity Build(StockItemsDto stockItemsDto, ApplicationUser user) =>
        new StockItemsEntity(stockItemsDto.ncode,
        stockItemsDto.title,
        stockItemsDto.writer,
        stockItemsDto.story,
        stockItemsDto.keyWord);
    public StockItemsDto Convert() => new StockItemsDto(ncode, title, writer, story, KeyWord);
}
