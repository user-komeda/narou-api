namespace NarouBackend.Presentation.Controllers;

using System.Security.Claims;
using Application;
using Application.StockItems.Request;
using Application.StockItems.Response;
using Bunit;
using FluentAssertions;
using Infrastructure;
using Infrastructure.StockItems.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockItems;
using util;
using Xunit;
using Xunit.Abstractions;


public sealed class StockItemsControllerTests : TestContext {
    [Fact] public void ShouldThrowBadRequests() {
        var stockItemsInput = new StockItemsInput("ncode", "title", "writer", "story", "keyWord");
        var stockItemsOutput = new StockItemsOutput("ncode", "title", "writer", "story", "keyWord");
        var mockUserManager = new Mock<UserManager<ApplicationUser>>(
        Mock.Of<IUserStore<ApplicationUser>>(),
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null);
        mockUserManager.Setup(v => v.GetUserId(It.IsAny<ClaimsPrincipal>()))
            .Returns("965df755-9105-4f30-82e6-06888cba1142");
        var mockStockItemsCreateUseCase =
            new Mock<IBaseUseCase<StockItemsInput, StockItemsOutput>>();
        mockStockItemsCreateUseCase.Setup(v =>
                v.Invoke("965df755-9105-4f30-82e6-06888cba1142", stockItemsInput))
            .ReturnsAsync(stockItemsOutput);

        var controller = new StockItemsController();
        var result = controller.Create(mockUserManager.Object,
        mockStockItemsCreateUseCase.Object,
        "123",
        stockItemsInput);

        result.Result.Should().BeOfType<BadRequest>();
    }

    [Fact] public async Task ShouldCreateData201() {
        var stockItemsInput = new StockItemsInput("ncode", "title", "writer", "story", "keyWord");
        var stockItemsOutput = new StockItemsOutput("ncode", "title", "writer", "story", "keyWord");
        var mockUserManager = new Mock<UserManager<ApplicationUser>>(
        Mock.Of<IUserStore<ApplicationUser>>(),
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null);
        mockUserManager.Setup(v => v.GetUserId(It.IsAny<ClaimsPrincipal>()))
            .Returns("965df755-9105-4f30-82e6-06888cba1142");
        var mockStockItemsCreateUseCase =
            new Mock<IBaseUseCase<StockItemsInput, StockItemsOutput>>();
        mockStockItemsCreateUseCase.Setup(v =>
                v.Invoke("965df755-9105-4f30-82e6-06888cba1142", stockItemsInput))
            .ReturnsAsync(stockItemsOutput);

        var controller = new StockItemsController();
        var result = (Created<StockItemsOutput>)await controller.Create(mockUserManager.Object,
        mockStockItemsCreateUseCase.Object,
        "965df755-9105-4f30-82e6-06888cba1142",
        stockItemsInput);

        result.StatusCode.Should().Be(201);
        result.Location.Should()
            .Be(
            $"http://localhost:5202/users/965df755-9105-4f30-82e6-06888cba1142/stockitems/create");
        result.Value.Should().BeEquivalentTo(stockItemsOutput);
    }
}
