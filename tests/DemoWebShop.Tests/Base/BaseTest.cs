using CleanTest.Framework.Drivers.WebDriver.Enums;
using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using CleanTest.Framework.Factories;

namespace DemoWebShop.Tests.Base;

public class BaseTest
{
    protected IWebDriverAdapter driver;  

    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.Create(WebDriverType.Playwright, BrowserType.Chrome, false);
    }
    
    [TearDown]
    public void TearDown()
    {
        Thread.Sleep(1000);
        if (driver != null)
        {
            driver.Dispose();
        }
    }
}