using DemoWebShop.Application.Entities;
using DemoWebShop.Application.UseCases;
using DemoWebShop.Tests.Base;
using NUnit.Framework;

namespace DemoWebShop.Tests;

public class LoginTests : BaseTest
{
    private AuthenticationUseCases? authentication;

    [SetUp]
    public void SetUp()
    {
        authentication = new AuthenticationUseCases(driver);
    }

    [Test]
    [TestCase("mitsram401@gmail.com", "Default12345")]
    public void Should_LoginSuccessfully_WhenValidCredentialsProvided(string username, string password)
    {
        // Arrange
        var user = new User { Username = username, Password = password };

        // Act
        authentication!.NavigateToLoginWidget();
        var loginResult = authentication.AttemptLogin(user);

        // Assert
        Assert.That(loginResult, Is.True, @"Login attempt for ${username} failed unexpectedly.");
    }

    [Test]
    public void Should_FailLogin_WhenInvalidCredentialsProvided()
    {
        // Test implementation
    }

    [Test]
    public void Should_LockAccount_WhenMaxLoginAttemptsExceeded()
    {
        // Test implementation
    }

    [Test]
    public void Should_ResetPassword_WhenValidEmailProvided()
    {
        // Test implementation
    }
}