using Application.Products.UpdateProduct;
using Domain.Products;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Products;

public class UpdateProduct : IEndpoint
{
    internal record UpdateProductDto(
        string Title,
        string Description,
        double Price,
        uint Quantity,
        string Sku,
        Category Category);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/products/{id}", async (
            ISender sender, 
            Guid id,
            UpdateProductDto dto) =>
        {
            UpdateProductCommand command = new(
                id,
                dto.Title,
                dto.Description,
                dto.Price,
                dto.Quantity,
                dto.Sku,
                dto.Category);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(UpdateProduct))
            .WithTags(Tags.Products);
    }
}
