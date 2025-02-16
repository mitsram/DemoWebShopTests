using CleanTest.Framework.Drivers.WebDriver.Interfaces;

namespace DemoWebShop.Application.PageObjects;

public class CartPage : BasePage
{
    public CartPage(IWebDriverAdapter webdriverAdapter) : base(webdriverAdapter)
    {
    }
    
    public void ClickOnTermsOfService()
    {
        var termsOfServiceCheckbox = driver.FindElementById("termsofservice");
        termsOfServiceCheckbox.Click();
    }
    
    public void ClickOnCheckoutButton()
    {
        var checkoutButton = driver.FindElementById("checkout");
        checkoutButton.Click();
    }
}