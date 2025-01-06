namespace NarouBackend.Presentation.Controllers.StockItems;

using Application.StockItems.Request;
using Application.StockItems.Response;
using Application.StockItems.UseCase;
using Infrastructure.StockItems.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NarouBackend.Application;
using NarouBackend.Infrastructure;
using NarouBackend.util;


[ApiController]
[Microsoft.AspNetCore.Mvc.Route("users/{pathUserId}/stockitems")]
[ProducesResponseType<StockItemsOutput>(StatusCodes.Status201Created)]
public class StockItemsController : ControllerBase {

    [HttpPost("create")] [Authorize] public async Task<IResult>
        Create(
            [FromServices] UserManager<ApplicationUser> userManager,
            [FromKeyedServices(nameof(StockItemsCreateUseCase))]
            IBaseUseCase<StockItemsInput, StockItemsOutput> createUseCase,
            [FromRoute] string pathUserId, [FromBody] StockItemsInput input) {
        var userId = userManager.GetUserId(User) ?? "";
        if (!userId.Equals(pathUserId)){
            return Results.BadRequest();
        }

        var createdData = await createUseCase.Invoke(userId, input);

        return Results.Created(new Uri($"http://localhost:5202/users/{userId}/stockitems/create"),
        createdData);
    }

    // [HttpDelete("/delete")] public Task<ActionResult> delete(int userId, string ncode) {}
}
