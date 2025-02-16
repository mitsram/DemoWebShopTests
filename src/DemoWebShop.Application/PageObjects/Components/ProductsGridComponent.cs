using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using Microsoft.Playwright;

namespace DemoWebShop.Application.PageObjects;

public class ProductsGridComponent : BasePage
{
    public ProductsGridComponent(IWebDriverAdapter webdriverAdapter) : base(webdriverAdapter)
    {
    }
    
    public void AddProductToCart(string productName)
    {
        // Find product grid container
        var productGrid = driver.FindElementByClassName("product-grid");
        
        // Find product item box containing the specific product title
        var productItem =
            productGrid.FindElementByXPath($"//h2[@class='product-title']/a[normalize-space()='{productName}']");
        productItem.Click();
        
        // Find and click the add to cart button
        var addToCartButton = driver.FindElementByClassName("add-to-cart-button");
        addToCartButton.Click();
    }
}
