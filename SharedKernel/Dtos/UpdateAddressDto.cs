namespace SharedKernel.Dtos;

public record UpdateAddressDto(
    Guid Id,
    string Apartment,
    string Floor,
    string Building,
    string Street,
    string City,
    string Country,
    string Governate,
    string PostalCode);

