using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class LoginPage : BasePage
{

    [FindsBy(How = How.Id, Using = "user-name")]
    private IWebElement _userNameInput;

    [FindsBy(How = How.Id, Using = "password")]
    private IWebElement _passwordInput;

    [FindsBy(How = How.Id, Using = "login-button")]
    private IWebElement _loginButton;

    [FindsBy(How = How.CssSelector, Using = "h3[data-test='error']")]
    private IWebElement _errorMessage;

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _loginButton.Displayed);
    }
    
    public LoginPage SetUserName(string username)
    {
        _userNameInput.SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        _passwordInput.SendKeys(password);
        return this;
    }

    public void ClickLoginButton()
    {
        _loginButton.Click();
    }
    
    public InventoryPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        SetUserName(username)
            .SetPassword(password)
            .ClickLoginButton();
            
        return new InventoryPage(_driver);
    }

    public string GetErrorMessage()
    {
        return _errorMessage.Text;
    }
}