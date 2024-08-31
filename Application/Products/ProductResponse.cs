namespace Application.Products;

public record ProductResponse(
    Guid Id,
    string Title,
    string Description,
    double Price,
    DateTime AddedOnUtc,
    uint Quantity,
    string Sku,
    string Category);
