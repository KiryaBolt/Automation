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
        loginPage.OpenSauceDemo();
        
        var inventoryPage = loginPage.Login("standard_user", "secret_sauce");

        inventoryPage.AddBackpackToCart();
        var cartPage = inventoryPage.Header.ClickCart();
 
        var checkoutStepOnePage = cartPage.ClickCheckout();

        var checkoutStepTwoPage = checkoutStepOnePage.ContinueCheckout("John", "Doe", "12345");

        var checkoutCompletePage = checkoutStepTwoPage.FinishCheckout();

        var expectedMessage = "Thank you for your order!";
        var actualMessage = checkoutCompletePage.GetCompleteMessageText();

        Assert.That(actualMessage, Is.EqualTo(expectedMessage), 
            "Сообщение об успешной покупке не совпадает с ожидаемым.");
    }
}