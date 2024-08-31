using Domain.Products;
using Domain.Users;

namespace Domain.Gifts;

public class Gift
{
    private readonly List<Product> _products = [];

    public Gift()
    {
    }

    public Gift(
        List<Product> products,
        Guid id,
        string name,
        string description,
        DateTime createdAtUtc,
        User createdBy)
    {
        _products = products;
        Id = id;
        Name = name;
        Description = description;
        CreatedAtUtc = createdAtUtc;
        CreatedBy = createdBy;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAtUtc { get; private set; }
    public User CreatedBy { get; private set; } = new();
    public List<Product> Products => _products;
    public double TotalPrice => _products.Sum(product => product.Price);

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }
}

