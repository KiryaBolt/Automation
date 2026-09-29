using NUnit.Framework;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

public class LoginTests : BaseTest
{
    [Test]
    public void LoginSuccess()
    {
        var loginPage = new LoginPage(driver);
        var inventoryPage = loginPage.Login();
        
        Assert.That(inventoryPage.IsCartIconDisplayed(), Is.True);
    }

    [Test]
    public void LoginLockedUser()
    {
        var loginPage = new LoginPage(driver);

        loginPage.SetUserName("locked_out_user")
            .SetPassword("secret_sauce")
            .ClickLoginButton();
                 
        Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
}