namespace DemoWebShop.Application.Entities;

public record PaymentInformation(
    string CreditCardType,
    string CardholderName,
    string CardNumber,
    string ExpirationMonth,
    string ExpirationYear,
    string CVV,
    string? PONumber = null // For Purchase Order
);