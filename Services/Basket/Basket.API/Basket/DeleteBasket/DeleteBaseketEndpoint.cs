using Basket.API.Basket.StoreBasket;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.DeleteBasket;
public record DeleteBasketRequest(string UserName);
public record DeleteBasketResponse(bool isSuccess);
public class DeleteBaseketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));

            var response = result.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteBasket")
        .Produces<DeleteBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("DeleteBasket")
        .WithDescription("DeleteBasket"); ;
    }
}
