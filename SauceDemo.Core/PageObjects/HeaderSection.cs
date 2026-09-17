using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class HeaderSection : BasePage
{
    #region Elements
    private Button BurgerMenuBtn => new Button(_driver, By.Id("react-burger-menu-btn"));
    private Button LogoutBtn => new Button(_driver, By.Id("logout_sidebar_link"));
    private Button CartLink => new Button(_driver, By.ClassName("shopping_cart_link"));
    #endregion

    public HeaderSection(IWebDriver driver) : base(driver)
    {
    }

    #region Methods
    public HeaderSection OpenSideMenu()
    {
        BurgerMenuBtn.Click();
        
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(_ => LogoutBtn.IsDisplayed());

        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        LogoutBtn.Click();
        return new LoginPage(_driver);
    }

    public LoginPage Logout()
    {
        return OpenSideMenu().ClickLogoutButton();
    }

    public CartPage ClickCart()
    {
        CartLink.Click();
        return new CartPage(_driver);
    }
    #endregion
}