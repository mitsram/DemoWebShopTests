
using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using DemoWebShop.Application.Entities;
using DemoWebShop.Application.PageObjects;
using FluentAssertions;

namespace DemoWebShop.Application.UseCases;

public class AuthenticationUseCases
{
    private readonly ReturningCustomerWidget loginWidget;
    private readonly BasePage basePage;

    public AuthenticationUseCases(IWebDriverAdapter driver)
    {
        basePage = new BasePage(driver);
        loginWidget = new ReturningCustomerWidget(driver);
    }

    public void NavigateToLoginWidget()
    {
        basePage.NavigateToHomePage();
        basePage.ClickOnLoginLink();
        var isOnLoginPage = basePage.IsOnLoginPage();
        isOnLoginPage.Should().BeTrue();
    }

    public bool AttemptLogin(User user)
    {
        loginWidget.LoginAs(user.Username!, user.Password!);
        return basePage.IsLoggedIn(user.Username!);
    }
}