using Application.Common;
using Application.Products;
using Domain.Gifts;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Gifts.ListGifts;

public record ListGiftsQuery(int? PageSize, int? PageIndex) :
    IRequest<Result<PagedList<GiftResponse>, Error>>;

public class ListGiftsQueryHandler : IRequestHandler<ListGiftsQuery, Result<PagedList<GiftResponse>, Error>>
{
    private readonly IGiftRepository _giftRepository;

    public ListGiftsQueryHandler(IGiftRepository giftRepository)
    {
        _giftRepository = giftRepository;
    }

    public async Task<Result<PagedList<GiftResponse>, Error>> Handle(ListGiftsQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize ?? 4;
        int pageIndex = request.PageIndex ?? 1;

        IReadOnlyList<Gift> gifts = await _giftRepository.ListAsync(cancellationToken);

        IEnumerable<GiftResponse> giftResponses = gifts.Select(g =>
        {
            var productResponses = g.Products
                .Select(p => new ProductResponse(
                    Id: p.Id,
                    Title: p.Title,
                    Description: p.Description,
                    Price: p.Price,
                    AddedOnUtc: p.AddedOnUtc,
                    Quantity: p.Quantity,
                    Sku: p.Sku,
                    Category: Enum.GetName(p.Category)!))
                .ToList();

            return new GiftResponse(
                Id: g.Id,
                Name: g.Name,
                Description: g.Description,
                CreatedById: g.CreatedBy.Id,
                CreatedAtUtc: g.CreatedAtUtc,
                TotalPrice: g.TotalPrice,
                Products: productResponses);
        });

        var pagedList = PagedList<GiftResponse>.Create(
            list: giftResponses,
            pageSize: pageSize,
            pageIndex: pageIndex);

        return pagedList;
    }
}
