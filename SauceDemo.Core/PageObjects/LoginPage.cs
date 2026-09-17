using OpenQA.Selenium;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class LoginPage : BasePage
{
    private Input UserNameInput => new Input(_driver, By.Id("user-name"));
    private Input PasswordInput => new Input(_driver, By.Id("password"));
    private Button LoginBtn => new Button(_driver, By.Id("login-button"));
    private Label ErrorMessage => new Label(_driver, By.CssSelector("h3[data-test='error']"));

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }
    
    public bool IsLoginPageDisplayed()
    {
        return LoginBtn.IsDisplayed();
    }
    
    public LoginPage SetUserName(string username)
    {
        UserNameInput.SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        PasswordInput.SendKeys(password);
        return this;
    }

    public void ClickLoginButton()
    {
        LoginBtn.Click();
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
        return ErrorMessage.Text;
    }
}