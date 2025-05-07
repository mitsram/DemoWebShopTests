
using Allure.NUnit.Attributes;
using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using DemoWebShop.Application.Entities;
using DemoWebShop.Application.PageObjects;

namespace DemoWebShop.Application.UseCases;

public class ShopUseCases(IWebDriverAdapter driver)
{
    private readonly MainPage mainPage = new(driver);
    private readonly ProductsGridComponent productsGrid = new(driver);
    private readonly CartPage cartPage = new(driver);
    private readonly CheckoutPage checkoutPage = new(driver);
    
    [AllureStep("Search for product")]
    public void SearchProduct(string productName)
    {
        mainPage.SearchProduct(productName);
    }

    public void AddProductToCart(string productName)
    {
        productsGrid.AddProductToCart(productName);
    }
    
    public void GoToCart()
    {
        mainPage.ClickOnShoppingCart();
    }

    public void StartCheckout()
    {
        mainPage.ClickOnShoppingCart();
        cartPage.ClickOnTermsOfService();
        cartPage.ClickOnCheckoutButton();
    }
    
    
}
