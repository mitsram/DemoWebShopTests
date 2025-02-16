using CleanTest.Framework.Utils;
using DemoWebShop.Application.Entities;

namespace DemoWebShop.Tests.Data.Builders;

public class PaymentInformationBuilder
{
    private string? _creditCardType;
    private string? _cardholderName;
    private string? _cardNumber;
    private string? _expirationMonth;
    private string? _expirationYear;
    private string? _cvv;
    private string? _poNumber;
    private const string ResourceNamespace = "DemoWebShop.Tests.Data.Json.";

    private PaymentInformationBuilder()
    {
    }

    public static PaymentInformationBuilder CreateNew() => new();
    public static PaymentInformationBuilder CreateFromJson()
    {
        return LoadFromJson(ResourceNamespace + "PaymentInformation.json");
    }

    private static PaymentInformationBuilder LoadFromJson(string resourcePath)
    {
        var builder = new PaymentInformationBuilder();
        var paymentInformation = DataUtils.LoadFromJson<PaymentInformation, PaymentInformationBuilder>(resourcePath);
        
        return builder
            .WithCreditCardType(paymentInformation.CreditCardType)
            .WithCardholderName(paymentInformation.CardholderName)
            .WithCardNumber(paymentInformation.CardNumber)
            .WithExpirationDate(paymentInformation.ExpirationMonth, paymentInformation.ExpirationYear)
            .WithCVV(paymentInformation.CVV)
            .WithPONumber(paymentInformation.PONumber);
    }
    
    public PaymentInformationBuilder WithCreditCardType(string value)
    {
        _creditCardType = value;
        return this;
    }

    public PaymentInformationBuilder WithCardholderName(string value)
    {
        _cardholderName = value;
        return this;
    }

    public PaymentInformationBuilder WithCardNumber(string value)
    {
        _cardNumber = value;
        return this;
    }

    public PaymentInformationBuilder WithExpirationDate(string month, string year)
    {
        _expirationMonth = month;
        _expirationYear = year;
        return this;
    }
    
    public PaymentInformationBuilder WithCVV(string value)
    {
        _cvv = value;
        return this;
    }
    
    public PaymentInformationBuilder WithPONumber(string value)
    {
        _poNumber = value;
        return this;
    }
    
    public PaymentInformation Build()
    {
        return new PaymentInformation(
            _creditCardType ?? throw new ArgumentNullException(nameof(_creditCardType)),
            _cardholderName ?? throw new ArgumentNullException(nameof(_cardholderName)),
            _cardNumber ?? throw new ArgumentNullException(nameof(_cardNumber)),
            _expirationMonth ?? throw new ArgumentNullException(nameof(_expirationMonth)),
            _expirationYear ?? throw new ArgumentNullException(nameof(_expirationYear)),
            _cvv ?? throw new ArgumentNullException(nameof(_cvv)),
            _poNumber ?? throw new ArgumentNullException(nameof(_poNumber))
        );
    }
}