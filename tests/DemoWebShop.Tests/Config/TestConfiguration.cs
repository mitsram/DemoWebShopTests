using CleanTest.Framework.Drivers.WebDriver.Enums;
using Microsoft.Extensions.Configuration;

namespace DemoWebShop.Tests.Config;

public class TestConfiguration
{
    public string BaseUrl { get; }
    public WebDriverType WebDriverType { get; }
    public BrowserType BrowserType { get; }
    public Dictionary<string, object> Options { get; } = new();
    public int Timeout { get; }

    public TestConfiguration(IConfiguration configuration)
    {
        BaseUrl = configuration.GetValue<string>("TestSettings:BaseUrl", "");
        WebDriverType = configuration.GetValue<WebDriverType>("WebDriverType", WebDriverType.Selenium);
        BrowserType = configuration.GetValue<BrowserType>("BrowserType");
        configuration.GetSection("Options").Bind(Options);
        Timeout = configuration.GetValue<int>("TestSettings:Timeout", 30);
    }
}