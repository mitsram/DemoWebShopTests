using CleanTest.Framework.Utils;
using DemoWebShop.Application.Entities;

namespace DemoWebShop.Tests.Data.Builders;

public class AddressBuilder
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _company;
    private string? _country;
    private string? _city;
    private string? _address1;
    private string? _address2;
    private string? _zipPostalCode;
    private string? _phoneNumber;

    private const string ResourceNamespace = "DemoWebShop.Tests.Data.Json.";

    private AddressBuilder()
    {
    }

    public static AddressBuilder CreateNew() => new();
    public static AddressBuilder CreateFromJson(string jsonFileName)
    {
        return LoadFromJson(ResourceNamespace + jsonFileName);
    }
    
    private static AddressBuilder LoadFromJson(string resourcePath)
    {
        var builder = new AddressBuilder();
        var address = DataUtils.LoadFromJson<Address, AddressBuilder>(resourcePath);

        return builder
            .WithFirstName(address.FirstName)
            .WithLastName(address.LastName)
            .WithEmail(address.Email)
            .WithCompany(address.Company)
            .InCountry(address.Country)
            .InCity(address.City)
            .WithStreetAddress(address.Address1, address.Address2)
            .WithZipCode(address.ZipPostalCode)
            .WithPhoneNumber(address.PhoneNumber);
    }
    
    public AddressBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public AddressBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public AddressBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public AddressBuilder WithCompany(string company)
    {
        _company = company;
        return this;
    }
    
    public AddressBuilder InCountry(string country)
    {
        _country = country;
        return this;
    }

    public AddressBuilder InCity(string city)
    {
        _city = city;
        return this;
    }

    public AddressBuilder WithStreetAddress(string address1, string address2 = null)
    {
        _address1 = address1;
        _address2 = address2;
        return this;
    }

    public AddressBuilder WithZipCode(string zipPostalCode)
    {
        _zipPostalCode = zipPostalCode;
        return this;
    }

    public AddressBuilder WithPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
        return this;
    }
    
    public Address Build()
    {
        return new Address
        {
            FirstName = _firstName ?? throw new ArgumentNullException(nameof(_firstName)),
            LastName = _lastName ?? throw new ArgumentNullException(nameof(_lastName)),
            Email = _email ?? throw new ArgumentNullException(nameof(_email)),
            Company = _company,
            Country = _country ?? throw new ArgumentNullException(nameof(_country)),
            City = _city ?? throw new ArgumentNullException(nameof(_city)),
            Address1 = _address1 ?? throw new ArgumentNullException(nameof(_address1)),
            Address2 = _address2,
            ZipPostalCode = _zipPostalCode ?? throw new ArgumentNullException(nameof(_zipPostalCode)),
            PhoneNumber = _phoneNumber ?? throw new ArgumentNullException(nameof(_phoneNumber))
        };
    }
}