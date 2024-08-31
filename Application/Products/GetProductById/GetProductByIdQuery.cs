using Application.Products;
using Domain.Products;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) :
    IRequest<Result<ProductResponse, Error>>;

public class GetProductByIdQueryHandler :
    IRequestHandler<GetProductByIdQuery, Result<ProductResponse, Error>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse, Error>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product == null)
        {
            return ProductErrors.ProductNotFound;
        }

        return new ProductResponse(
            Id: product.Id,
            Title: product.Title,
            Description: product.Description,
            Price: product.Price,
            AddedOnUtc: product.AddedOnUtc,
            Quantity: product.Quantity,
            Sku: product.Sku,
            Category: Enum.GetName(product.Category)!);
    }
}
