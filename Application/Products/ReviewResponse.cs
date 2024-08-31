namespace Application.Products;

public record ReviewResponse(
    Guid Id,
    string? Comment,
    uint Rating,
    Guid AddedById,
    Guid ProductId);