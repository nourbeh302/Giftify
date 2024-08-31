namespace Domain.Products;

public class Product
{
    public Product()
    {
    }

    public Product(
        Guid id,
        string title,
        string description,
        double price,
        DateTime addedOnUtc,
        uint quantity,
        Category category,
        string sku)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        AddedOnUtc = addedOnUtc;
        Quantity = quantity;
        Category = category;
        Sku = sku;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public double Price { get; private set; }
    public DateTime AddedOnUtc { get; private set; }
    public uint Quantity { get; set; }
    public string Sku { get; private set; } = string.Empty;
    public Category Category { get; private set; }
}
