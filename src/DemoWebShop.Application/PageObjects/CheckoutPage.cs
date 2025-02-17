using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using DemoWebShop.Application.Entities;

namespace DemoWebShop.Application.PageObjects;

public class CheckoutPage : BasePage
{
    public CheckoutPage(IWebDriverAdapter webdriverAdapter) : base(webdriverAdapter)
    {
    }
    
    public void ClickContinueOnBillingAddress()
    {
        Thread.Sleep(1000);
        var container = driver.FindElementById("billing-buttons-container");
        var continueButton = container.FindElementByClassName("new-address-next-step-button");
        continueButton.Click();
    }
    
    public void ClickContinueOnShippingAddress()
    {
        var container = driver.FindElementById("shipping-buttons-container");
        var continueButton = container.FindElementByClassName("new-address-next-step-button");
        continueButton.Click();
    }
    
    public void ClickContinueOnShippingMethod()
    {
        var container = driver.FindElementById("shipping-method-buttons-container");
        var continueButton = container.FindElementByClassName("shipping-method-next-step-button");
        continueButton.Click();
    }
    
    public void ClickContinueOnPaymentMethod()
    {
        var container = driver.FindElementById("payment-method-buttons-container");
        var continueButton = container.FindElementByClassName("payment-method-next-step-button");
        continueButton.Click();
    }
    
    public void ClickContinueOnPaymentInformation()
    {
        var container = driver.FindElementById("payment-info-buttons-container");
        var continueButton = container.FindElementByClassName("payment-info-next-step-button");
        continueButton.Click();
    }
    
    public void SelectPaymentMethod(PaymentMethod method)
    {
        Thread.Sleep(1000);
        var methodName = method switch
        {
            PaymentMethod.CreditCard => "Credit Card",
            PaymentMethod.CashOnDelivery => "Cash On Delivery",
            PaymentMethod.PurchaseOrder => "Purchase Order",
            PaymentMethod.CheckOrMoneyOrder => "Check / Money Order",
            _ => throw new ArgumentOutOfRangeException(nameof(method))
        };
        var radio = driver.FindElementByXPath($"//label[contains(., '{methodName}')]/preceding-sibling::input[@type='radio']");
        radio.Click();
    }
    
    public void FillBillingAddress(Address data)
    {
        driver.FindElementById("BillingNewAddress_FirstName").SendKeys(data.FirstName);
        driver.FindElementById("BillingNewAddress_LastName").SendKeys(data.LastName);
        driver.FindElementById("BillingNewAddress_Email").SendKeys(data.Email);
        driver.FindElementById("BillingNewAddress_CountryId").SelectOptionByText(data.Country);
        driver.FindElementById("BillingNewAddress_City").SendKeys(data.City);
        driver.FindElementById("BillingNewAddress_Address1").SendKeys(data.Address1);
        driver.FindElementById("BillingNewAddress_Address2").SendKeys(data.Address2);
        driver.FindElementById("BillingNewAddress_ZipPostalCode").SendKeys(data.ZipPostalCode);
        driver.FindElementById("BillingNewAddress_PhoneNumber").SendKeys(data.PhoneNumber);
    }

    public void FillShippingAddress(Address data)
    {
        driver.FindElementById("ShippingNewAddress_FirstName").SendKeys(data.FirstName);
        driver.FindElementById("ShippingNewAddress_LastName").SendKeys(data.LastName);
        driver.FindElementById("ShippingNewAddress_Email").SendKeys(data.Email);
        driver.FindElementById("ShippingNewAddress_CountryId").SelectOptionByText(data.Country);
        driver.FindElementById("ShippingNewAddress_City").SendKeys(data.City);
        driver.FindElementById("ShippingNewAddress_Address1").SendKeys(data.Address1);
        driver.FindElementById("ShippingNewAddress_Address2").SendKeys(data.Address2);
        driver.FindElementById("ShippingNewAddress_ZipPostalCode").SendKeys(data.ZipPostalCode);
        driver.FindElementById("ShippingNewAddress_PhoneNumber").SendKeys(data.PhoneNumber);
    }

    public void FillPaymentInformation(PaymentInformation data)
    {
        Thread.Sleep(1000);
        driver.FindElementById("CreditCardType").SelectOptionByText(data.CreditCardType);
        driver.FindElementById("CardholderName").SendKeys(data.CardholderName);
        driver.FindElementById("CardNumber").SendKeys(data.CardNumber);
        driver.FindElementById("ExpireMonth").SelectOptionByText(data.ExpirationMonth);
        driver.FindElementById("ExpireYear").SelectOptionByText(data.ExpirationYear);
        driver.FindElementById("CardCode").SendKeys(data.CVV);
    }
    
    public void ConfirmOrder()
    {
        Thread.Sleep(1000);
        var container = driver.FindElementById("confirm-order-buttons-container");
        var continueButton = container.FindElementByClassName("confirm-order-next-step-button");
        continueButton.Click();
    }
    
    public bool IsOrderSuccessfullyProcessed()
    {
        Thread.Sleep(5000);
        return driver.FindElementByText("Your order has been successfully processed!").IsDisplayed();
        // var successMessage = driver.FindElementByClassName("order-completed");
        // return successMessage.IsDisplayed();
    }
}