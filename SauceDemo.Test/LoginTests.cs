using NUnit.Framework;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

public class LoginTests : BaseTest
{
    [Test]
    public void LoginSuccess()
    {
        LoginPage loginPage = new LoginPage(driver);
        InventoryPage inventoryPage = loginPage.Login();
        Assert.That(inventoryPage.IsCartIconDisplayed(), Is.True);
    }

    [Test]
    public void LoginLockedUser()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login(username: "locked_out_user");
        Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
}