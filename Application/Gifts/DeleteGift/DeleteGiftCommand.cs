using Domain.Gifts;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Gifts.DeleteGift;

public record DeleteGiftCommand(
    Guid Id, 
    Guid CreatedById) :
    IRequest<Result<int, Error>>;

public class DeleteGiftCommandHandler : 
    IRequestHandler<DeleteGiftCommand, Result<int, Error>>
{
    private readonly IGiftRepository _giftRepository;

    public DeleteGiftCommandHandler(IGiftRepository giftRepository)
    {
        _giftRepository = giftRepository;
    }

    public async Task<Result<int, Error>> Handle(DeleteGiftCommand request, CancellationToken cancellationToken)
    {
        Gift? gift = await _giftRepository.GetByIdAsync(request.Id, cancellationToken);

        if (gift is null)
        {
            return GiftErrors.GiftNotFound;
        }
        
        await _giftRepository.DeleteAsync(request.Id, cancellationToken);

        return 1;
    }
}
