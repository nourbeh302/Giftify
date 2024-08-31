using Application.Products;
using Domain.Gifts;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Gifts.GetGiftById;

public record GetGiftByIdQuery(Guid Id) : IRequest<Result<GiftResponse, Error>>;

public class GetGiftByIdQueryHandler :
    IRequestHandler<GetGiftByIdQuery, Result<GiftResponse, Error>>
{
    private readonly IGiftRepository _giftRepository;

    public GetGiftByIdQueryHandler(IGiftRepository giftRepository)
    {
        _giftRepository = giftRepository;
    }

    public async Task<Result<GiftResponse, Error>> Handle(GetGiftByIdQuery request, CancellationToken cancellationToken)
    {
        Gift? gift = await _giftRepository.GetByIdAsync(request.Id, cancellationToken);

        if (gift == null)
        {
            return GiftErrors.GiftNotFound;
        }

        var productResponses = gift.Products
            .Select(p => new ProductResponse(
                p.Id,
                p.Title,
                p.Description,
                p.Price,
                p.AddedOnUtc,
                p.Quantity,
                p.Sku,
                Enum.GetName(p.Category)!))
            .ToList();

        return new GiftResponse(
            gift.Id,
            gift.Name,
            gift.Description,
            gift.CreatedBy.Id,
            gift.CreatedAtUtc,
            gift.TotalPrice,
            productResponses);
    }
}
