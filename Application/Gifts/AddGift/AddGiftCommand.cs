using Application.Products;
using Domain.Gifts;
using Domain.Products;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Gifts.AddGift;

public record AddGiftCommand(
    string Name,
    string Description,
    Guid CreatedById,
    List<Guid> ProductIds) :
    IRequest<Result<GiftResponse, Error>>;

public class AddGiftCommandHandler : IRequestHandler<AddGiftCommand, Result<GiftResponse, Error>>
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IGiftRepository _giftRepository;

    public AddGiftCommandHandler(
        IUserRepository userRepository,
        IProductRepository productRepository,
        IGiftRepository giftRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
        _giftRepository = giftRepository;
    }

    public async Task<Result<GiftResponse, Error>> Handle(AddGiftCommand request, CancellationToken cancellationToken)
    {
        User? createdBy = await _userRepository.GetByIdAsync(request.CreatedById, cancellationToken);

        if (createdBy is null)
        {
            return UserErrors.UserNotFound;
        }

        Gift newGift = new(
            id: Guid.NewGuid(),
            name: request.Name,
            description: request.Description,
            products: [],
            createdBy: createdBy,
            createdAtUtc: DateTime.UtcNow);

        foreach (Guid productId in request.ProductIds)
        {
            Product? product = await _productRepository.GetByIdAsync(productId, cancellationToken);

            newGift.AddProduct(product!);
        }

        Gift gift = await _giftRepository.AddAsync(newGift, cancellationToken);

        return new GiftResponse(
            Id: gift.Id,
            Name: gift.Name,
            Description: gift.Description,
            CreatedById: gift.CreatedBy.Id,
            CreatedAtUtc: gift.CreatedAtUtc,
            TotalPrice: gift.TotalPrice,
            Products: gift.Products
               .Select(p => new ProductResponse(
                   Id: p.Id,
                   Title: p.Title,
                   Description: p.Description,
                   Price: p.Price,
                   AddedOnUtc: p.AddedOnUtc,
                   Quantity: p.Quantity,
                   Sku: p.Sku,
                   Category: Enum.GetName(p.Category)!))
               .ToList());
    }
}
