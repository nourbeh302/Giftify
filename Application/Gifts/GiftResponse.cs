using Application.Products;

namespace Application.Gifts;

public record GiftResponse(
    Guid Id,
    string Name,
    string Description,
    Guid CreatedById,
    DateTime CreatedAtUtc,
    double TotalPrice,
    List<ProductResponse> Products);
