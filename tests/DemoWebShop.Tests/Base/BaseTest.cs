using CleanTest.Framework.Drivers.WebDriver.Enums;
using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using CleanTest.Framework.Factories;
using DemoWebShop.Tests.Config;
using DotNetEnv;
using Microsoft.Extensions.Configuration;

namespace DemoWebShop.Tests.Base;

public class BaseTest
{
    protected IWebDriverAdapter driver;  

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Env.TraversePath().Load();
    }
    
    [SetUp]
    public void Setup()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(TestContext.CurrentContext.TestDirectory)
            .AddJsonFile("Config/appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        var config = new TestConfiguration(configuration);

        driver = WebDriverFactory.Create(config.WebDriverType, config.BrowserType, config.Options);
        driver.NavigateToUrl(config.BaseUrl);
    }
    
    [TearDown]
    public void TearDown()
    {
        Thread.Sleep(1000);
        driver.Dispose();
    }
}