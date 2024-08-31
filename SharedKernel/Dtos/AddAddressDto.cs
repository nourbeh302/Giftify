namespace SharedKernel.Dtos;

public record AddAddressDto(
    string Apartment,
    string Floor,
    string Building,
    string Street,
    string City,
    string Country,
    string Governate,
    string PostalCode);

