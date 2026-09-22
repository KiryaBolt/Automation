using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class HeaderSection : BasePage
{
    [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
    private IWebElement _burgerMenuBtn;

    [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
    private IWebElement _logoutBtn;

    [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
    private IWebElement _cartLink;

    public HeaderSection(IWebDriver driver) : base(driver)
    {
    }

    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _burgerMenuBtn.Displayed);
    }

    public HeaderSection OpenSideMenu()
    {
        _burgerMenuBtn.Click();
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => _logoutBtn.Displayed);
        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        _logoutBtn.Click();
        return new LoginPage(_driver);
    }

    public LoginPage Logout()
    {
        return OpenSideMenu().ClickLogoutButton();
    }

    public CartPage ClickCart()
    {
        _cartLink.Click();
        return new CartPage(_driver);
    }
}