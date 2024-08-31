namespace Domain.Orders;

public class Address
{
    public Address()
    {
    }

    public Address(
        Guid id,
        string apartment,
        string floor,
        string building,
        string street,
        string city,
        string country,
        string governate,
        string postalCode)
    {
        Id = id;
        Apartment = apartment;
        Floor = floor;
        Building = building;
        Street = street;
        City = city;
        Country = country;
        Governate = governate;
        PostalCode = postalCode;
    }

    public Guid Id { get; private set; }
    public string Apartment { get; private set; } = string.Empty;
    public string Floor { get; private set; } = string.Empty;
    public string Building { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public string Governate { get; private set; } = string.Empty;
    public string PostalCode { get; private set; } = string.Empty;

    public string FormatAddress()
    {
        return $"{Apartment}, {Floor}, {Building}, {Street}, {City}, {Governate}, {PostalCode}, {Country}";
    }
}