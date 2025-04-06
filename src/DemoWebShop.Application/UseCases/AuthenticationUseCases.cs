
using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using DemoWebShop.Application.Entities;
using DemoWebShop.Application.PageObjects;
using FluentAssertions;

namespace DemoWebShop.Application.UseCases;

public class AuthenticationUseCases(IWebDriverAdapter driver)
{
    private readonly ReturningCustomerComponent loginComponent = new(driver);
    private readonly BasePage basePage = new(driver);

    public void NavigateToLoginWidget()
    {        
        basePage.ClickOnLoginLink();
        var isOnLoginPage = basePage.IsOnLoginPage();
        isOnLoginPage.Should().BeTrue();
    }

    public bool AttemptLogin(User user)
    {
        loginComponent.LoginAs(user.Username!, user.Password!);
        return basePage.IsLoggedIn(user.Username!);
    }
}