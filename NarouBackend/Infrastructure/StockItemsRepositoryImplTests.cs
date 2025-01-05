namespace NarouBackend.Infrastructure;

using Bunit;
using Domain.StockItems.Dto;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using StockItems.DbContext;
using StockItems.Entity;
using Xunit;


public class StockItemsRepositoryImplTests : TestContext {
    [Fact] public async Task ShouldSaveStockItem() {
        var applicationUser = new ApplicationUser();
        var stockItemsDto = new StockItemsDto("ncode", "title", "writer", "story", "keyWord");
        var dbContext = new Mock<DbContext>();
        dbContext.Setup((context => context.SaveChangesAsync(new CancellationToken())))
            .ReturnsAsync(1);
        Services.AddDbContext<AppDbContext>(options => { options.UseSqlite("DataSource=app.db"); });

        var stockItemsRepository = new StockItemsRepositoryImpl(dbContext.Object);
        var result = await stockItemsRepository.Create(applicationUser, stockItemsDto);
        result.Should().BeEquivalentTo(stockItemsDto);
    }
}
