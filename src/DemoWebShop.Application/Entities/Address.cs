namespace DemoWebShop.Application.Entities;

public record Address
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Company { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string ZipPostalCode { get; init; }
    public string PhoneNumber { get; init; }
}