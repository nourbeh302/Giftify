using Domain.Users;

namespace Domain.Products;

public class Review
{
    public Review()
    {
    }

    public Review(
        Guid id,
        DateTime addedOnUtc,
        User addedBy,
        Rating rating,
        string? comment,
        Product product)
    {
        Id = id;
        AddedOnUtc = addedOnUtc;
        AddedBy = addedBy;
        Rating = rating;
        Comment = comment;
        Product = product;
    }

    public Guid Id { get; private set; }
    public DateTime AddedOnUtc { get; private set; }
    public User AddedBy { get; private set; } = new();
    public Product Product { get; private set; } = new();
    public Rating Rating { get; private set; }
    public string? Comment { get; private set; } = string.Empty;
}
