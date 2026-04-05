namespace NarouBackend.Infrastructure.StockItems.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NarouBackend.Domain.StockItems.Dto;

public sealed class StockItemsEntity {
    public StockItemsEntity(
        string ncode,
        string title,
        string writer,
        string story,
        string keyWord) {
        Ncode = ncode;
        Title = title;
        Writer = writer;
        Story = story;
        KeyWord = keyWord;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string Ncode { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(100)]
    public string Writer { get; set; }

    [MaxLength(4000)]
    public string Story { get; set; }

    [MaxLength(200)]
    public string KeyWord { get; set; }
    
    [MaxLength(36)]
    public required string UserId { get; set; }
    public required ApplicationUser user { get; set; }

    public static StockItemsEntity Build(StockItemsDto stockItemsDto, ApplicationUser user) =>
        new StockItemsEntity(
            stockItemsDto.ncode,
            stockItemsDto.title,
            stockItemsDto.writer,
            stockItemsDto.story,
            stockItemsDto.keyWord) {
            UserId = user.Id,
            user = user
        };

    public StockItemsDto Convert() =>
        new StockItemsDto(Ncode, Title, Writer, Story, KeyWord);
}