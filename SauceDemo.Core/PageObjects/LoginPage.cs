using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class LoginPage : BasePage
{
    private readonly By _loginButton = By.Id("login-button");
    private readonly By _userNameInput = By.Id("user-name");
    private readonly By _passwordInput = By.Id("password");
    private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsLoginPageDisplayed()
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.FindElement(_loginButton).Displayed);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public LoginPage SetUserName(string username)
    {
        _driver.FindElement(_userNameInput).SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        _driver.FindElement(_passwordInput).SendKeys(password);
        return this;
    }

    public void ClickLoginButton()
    {
        _driver.FindElement(_loginButton).Click();
    }

    public InventoryPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        SetUserName(username);
        SetPassword(password);
        ClickLoginButton();
        return new InventoryPage(_driver);
    }

    public string GetErrorMessage()
    {
        return _driver.FindElement(_errorMessage).Text;
    }
}