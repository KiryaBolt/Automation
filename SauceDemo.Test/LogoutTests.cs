using NUnit.Framework;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

public class LogoutTests : BaseTest
{
    [Test]
    public void SuccessfulLogoutTest()
    {
        var loginPage = new LoginPage(driver);
        var inventoryPage = loginPage.Login();
        
        var newLoginPage = inventoryPage.Header.Logout();

        Assert.That(newLoginPage.GetUrl(), Is.EqualTo(Settings.BaseUrl), "Выход не удался!");
    }
}