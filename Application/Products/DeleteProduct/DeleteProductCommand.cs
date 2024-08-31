using Domain.Products;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) :
    IRequest<Result<int, Error>>;

public class DeleteProductCommandHandler :
    IRequestHandler<DeleteProductCommand, Result<int, Error>>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<int, Error>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            return ProductErrors.ProductNotFound;
        }

        await _productRepository.DeleteAsync(product.Id, cancellationToken);

        return 1;
    }
}
