using Application.Products.GetProductById;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Products;

public class GetProductById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(GetProductById))
            .WithTags(Tags.Products);
    }
}
