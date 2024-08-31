using Application.Products.DeleteProduct;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Products;

public class DeleteProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (ISender sender, Guid id) =>
        {
            var result = await sender.Send(new DeleteProductCommand(id));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(DeleteProduct))
            .WithTags(Tags.Products);
    }
}
