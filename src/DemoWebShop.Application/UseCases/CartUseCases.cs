using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using DemoWebShop.Application.PageObjects;

namespace DemoWebShop.Application.UseCases;

public class CartUseCases(IWebDriverAdapter driver)
{
    private readonly CartPage cartPage = new (driver);
    
    public void ProceedToCheckout()
    {
        cartPage.ClickOnTermsOfService();
        cartPage.ClickOnCheckoutButton();
    }
}