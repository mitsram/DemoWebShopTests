using CleanTest.Framework.Drivers.WebDriver.Interfaces;
using DemoWebShop.Application.Entities;
using DemoWebShop.Application.PageObjects;

namespace DemoWebShop.Application.UseCases;

public class CheckoutUseCases(IWebDriverAdapter driver)
{
    private readonly CheckoutPage checkoutPage = new(driver);
    
    public void CompletePurchase(PaymentInformation paymentInfomation)
    {
        ProvideBillingAddress();
        ProvideShippingAddress();
        ChooseShippingMethod(ShippingMethod.Standard);
        ProvidePaymentDetails(PaymentMethod.CreditCard, paymentInfomation);
        CompleteCheckout();
    }
    
    public void ProvideBillingAddress(Address? data = null)
    {
        if (data != null) checkoutPage.FillBillingAddress(data);
        checkoutPage.ClickContinueOnBillingAddress();
    }

    public void ProvideShippingAddress(Address? data = null)
    {
        if (data != null) checkoutPage.FillShippingAddress(data);
        checkoutPage.ClickContinueOnShippingAddress();
    }
    
    public void ChooseShippingMethod(ShippingMethod method)
    {
        var methodName = method switch
        {
            ShippingMethod.Standard => "Ground",
            ShippingMethod.NextDayAir => "Next Day Air",
            ShippingMethod.SecondDayAir => "2nd Day Air",
            _ => throw new ArgumentOutOfRangeException(nameof(method))
        };
        Thread.Sleep(1000);
        var radio = driver.FindElementByXPath($"//label[contains(., '{methodName}')]/preceding-sibling::input[@type='radio']");
        radio.Click();
        checkoutPage.ClickContinueOnShippingMethod();
    }
    
    
    public void ProvidePaymentDetails(PaymentMethod method, PaymentInformation? data = null)
    {
        checkoutPage.SelectPaymentMethod(method);
        checkoutPage.ClickContinueOnPaymentMethod();
        
        switch (method)
        {
            case PaymentMethod.CreditCard:            
                checkoutPage.FillPaymentInformation(data!);
                break;
                
            case PaymentMethod.CheckOrMoneyOrder:
                // Check requires no additional info
                break;
                
            case PaymentMethod.CashOnDelivery:
                break;
            
            case PaymentMethod.PurchaseOrder:
                driver.FindElementById("purchaseordernumber").SendKeys(data!.PONumber!);
                break;
            
            default:
                throw new ArgumentOutOfRangeException(
                    nameof(method), 
                    $"Unsupported payment method: {method}");
        }
        checkoutPage.ClickContinueOnPaymentInformation();
    }

    public void CompleteCheckout()
    {
        checkoutPage.ConfirmOrder();
    }

    public bool VerifyOrderConfirmation()
    {
        return checkoutPage.IsOrderSuccessfullyProcessed();
    }
}