using NUnit.Framework;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

public class LogoutTests : BaseTest
{
    [Test]
    public void SuccessfulLogoutTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        InventoryPage inventoryPage = loginPage.Login();
        LoginPage newLoginPage = inventoryPage.Header.Logout();
        Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True, "Выход не удался!");
    }
}