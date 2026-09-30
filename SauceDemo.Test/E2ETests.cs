using NUnit.Framework;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

[TestFixture]
public class E2ETests : BaseTest
{
    [Test]
    public void SuccessfulPurchaseFlowTest()
    {
        var loginPage = new LoginPage(driver);

        var actualMessage = loginPage
            .Login("standard_user", "secret_sauce")
            .AddBackpackToCart()
            .Header.ClickCart()
            .ClickCheckout()
            .ContinueCheckout("John", "Doe", "12345")
            .FinishCheckout()
            .GetCompleteMessageText();

        var expectedMessage = "Thank you for your order!";

        Assert.That(actualMessage, Is.EqualTo(expectedMessage), 
            "Сообщение об успешной покупке не совпадает с ожидаемым.");
    }
}