using DemoWebShop.Application.Entities;
using DemoWebShop.Application.UseCases;
using DemoWebShop.Tests.Base;
using DemoWebShop.Tests.Data.Builders;

namespace DemoWebShop.Tests;

public class CheckoutTests : BaseTest
{
    private AuthenticationUseCases? authentication;
    private ShopUseCases? shop;
    
    [SetUp]
    public void SetUp()
    {
        authentication = new AuthenticationUseCases(driver);
        shop = new ShopUseCases(driver);
    }

    [Test]
    public void Should_CompleteCheckout_WhenValidPaymentProvided()
    {
        // Arrange
        var user = new User { Username = "mitsram401@gmail.com", Password = "Default12345" };        
        var paymentInfomation = PaymentInformationBuilder.CreateFromJson().Build();
        

        // Act
        authentication!.NavigateToLoginWidget();
        authentication.AttemptLogin(user);
        
        shop!.SearchProduct("Blue Jeans");
        shop.AddProductToCart("Blue Jeans");
        shop.StartCheckout();
        shop.ProvideBillingAddress();
        shop.ProvideShippingAddress();
        shop.ChooseShippingMethod(ShippingMethod.Standard);
        shop.ProvidePaymentDetails(PaymentMethod.CreditCard, paymentInfomation);        
        shop.CompleteCheckout();
        shop.VerifyOrderConfirmation();

        // Assert
    }
}