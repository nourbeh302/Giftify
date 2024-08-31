using Application.Products.ListProducts;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Products;

public class ListProducts : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (
            ISender sender,
            string? searchTerm,
            int? pageSize,
            int? pageIndex) =>
        {
            ListProductsQuery query = new(
                SearchTerm: searchTerm,
                PageSize: pageSize,
                PageIndex: pageIndex);

            var result = await sender.Send(query);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(ListProducts))
            .WithTags(Tags.Products);
    }
}
