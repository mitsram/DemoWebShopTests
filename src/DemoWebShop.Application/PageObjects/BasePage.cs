using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using Microsoft.Playwright;

namespace DemoWebShop.Application.PageObjects;


public class BasePage
{
    protected readonly IWebDriverAdapter driver;

    public BasePage(IWebDriverAdapter webdriverAdapter)
    {
        driver = webdriverAdapter;
    }

    public void NavigateToHomePage()
    {
        driver.NavigateToUrl("https://demowebshop.tricentis.com/");
    }

    public void ClickOnLoginLink()
    {
        driver.FindElementByRole(AriaRole.Link, "Log in").Click();
    }

    public bool IsOnLoginPage()
    {
        return driver.GetCurrentUrl().EndsWith("/login");
    }

    public bool IsLoggedIn(string username)
    {
        return driver.FindElementByClassName("account").Nth(1).IsDisplayed();
    }
}