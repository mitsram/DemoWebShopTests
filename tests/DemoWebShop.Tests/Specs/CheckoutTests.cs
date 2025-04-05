using DemoWebShop.Application.Entities;
using DemoWebShop.Application.UseCases;
using DemoWebShop.Tests.Base;
using DemoWebShop.Tests.Data.Builders;

namespace DemoWebShop.Tests;

public class CheckoutTests : BaseTest
{
    private AuthenticationUseCases? authentication;
    private ShopUseCases? shop;
    private CartUseCases? cart;
    private CheckoutUseCases? checkout;
    
    [SetUp]
    public void SetUp()
    {
        authentication = new AuthenticationUseCases(driver);
        shop = new ShopUseCases(driver);
        cart = new CartUseCases(driver);
        checkout = new CheckoutUseCases(driver);
        
        var user = new User { Username = Environment.GetEnvironmentVariable("USERNAME"), Password = Environment.GetEnvironmentVariable("PASSWORD") };
        authentication!.NavigateToLoginWidget();
        authentication.AttemptLogin(user);
    }

    [Test]
    [Category("Smoke")]
    public void Should_CompleteCheckout_WhenValidPaymentProvided()
    {
        // Arrange
        var product = new Product { Name = "Blue Jeans"};
        var paymentInfomation = PaymentInformationBuilder.CreateFromJson().Build();

        // Act
        shop!.SearchProduct(product.Name);
        shop.AddProductToCart(product.Name);
        shop.GoToCart();
        cart!.ProceedToCheckout();
        checkout!.CompletePurchase(paymentInfomation);
        var result = checkout.VerifyOrderConfirmation();

        // Assert
        Assert.That(result, Is.True, "Order confirmation was not shown");
        
    }
}