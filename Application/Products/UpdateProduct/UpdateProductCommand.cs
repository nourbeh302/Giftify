using Application.Products;
using Domain.Products;
using FluentValidation.Results;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Title,
    string Description,
    double Price,
    uint Quantity,
    string Sku,
    Category Category) :
    IRequest<Result<ProductResponse, Error>>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponse, Error>>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse, Error>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        UpdateProductCommandValidator validator = new();

        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return ProductErrors.InvalidEntry;
        }

        Product? oldProduct = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (oldProduct is null)
        {
            return ProductErrors.ProductNotFound;
        }

        Product newProduct = new(
            id: oldProduct.Id,
            title: request.Title,
            description: request.Description,
            price: request.Price,
            addedOnUtc: oldProduct.AddedOnUtc,
            quantity: request.Quantity,
            category: request.Category,
            sku: request.Sku);

        Product product = await _productRepository.UpdateAsync(newProduct, cancellationToken);

        return new ProductResponse(
            Id: product.Id,
            Title: product.Title, Description: product.Description,
            Price: product.Price,
            AddedOnUtc: product.AddedOnUtc,
            Quantity: product.Quantity,
            Sku: product.Sku,
            Category: Enum.GetName(product.Category)!);
    }
}