
using CleanTest.Framework.Drivers.WebDriver.Interfaces;

namespace DemoWebShop.Application.PageObjects;


public class ReturningCustomerWidget : BasePage
{
    public ReturningCustomerWidget(IWebDriverAdapter webdriverAdapter) : base(webdriverAdapter)
    {
    }
    public void LoginAs(string username, string password)
    {
        var usernameField = driver.FindElementByLabel("Email:");
        var passwordField = driver.FindElementByLabel("Password:");
        var loginButton = driver.FindElementByClassName("login-button");

        usernameField.SendKeys(username);
        passwordField.SendKeys(password);
        loginButton.Click(); 
    }
}