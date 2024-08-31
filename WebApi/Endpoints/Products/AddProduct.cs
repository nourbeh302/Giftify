using Application.Products.AddProduct;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Products;

public class AddProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (ISender sender, AddProductCommand command) =>
        {
            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(AddProduct))
            .WithTags(Tags.Products);
    }
}
