using CleanTest.Framework.Drivers.WebDriver.Interfaces;

namespace DemoWebShop.Application.PageObjects;

public class MainPage : BasePage
{
    public MainPage(IWebDriverAdapter webdriverAdapter) : base(webdriverAdapter)
    {
    }
    
    public void SearchProduct(string productName)
    {
        var searchBox = driver.FindElementById("small-searchterms");
        searchBox.SendKeys(productName);
        var searchButton = driver.FindElementByClassName("search-box-button");
        searchButton.Click();
    }
    
    public void ClickOnShoppingCart()
    {
        driver.FindElementById("topcartlink").Click();
    }
}