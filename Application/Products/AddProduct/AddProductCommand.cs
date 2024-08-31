using Application.Products;
using Domain.Products;
using FluentValidation.Results;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Products.AddProduct;

public record AddProductCommand(
    string Title,
    string Description,
    double Price,
    uint Quantity,
    string Sku,
    Category Category) :
    IRequest<Result<ProductResponse, Error>>;

public class AddProductCommandHandler :
    IRequestHandler<AddProductCommand, Result<ProductResponse, Error>>
{
    private readonly IProductRepository _productRepository;

    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse, Error>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        AddProductCommandValidator validator = new();

        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return ProductErrors.InvalidEntry;
        }

        Product newProduct = new(
            id: Guid.NewGuid(),
            title: request.Title,
            description: request.Description,
            price: request.Price,
            addedOnUtc: DateTime.UtcNow,
            quantity: request.Quantity,
            category: request.Category,
            sku: request.Sku);

        Product product = await _productRepository.AddAsync(newProduct, cancellationToken);

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