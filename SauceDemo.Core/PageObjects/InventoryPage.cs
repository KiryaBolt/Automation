using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class InventoryPage : BasePage
{

    [FindsBy(How = How.CssSelector, Using = "a[data-test='shopping-cart-link']")]
    private IWebElement _cartIcon;

    [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
    private IWebElement _addBackpackBtn;
    
    public HeaderSection Header => new HeaderSection(_driver);

    public InventoryPage(IWebDriver driver) : base(driver)
    {
    }

    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _cartIcon.Displayed);
    }

    public bool IsCartIconDisplayed()
    {
        return _cartIcon.Displayed;
    }

    public InventoryPage AddBackpackToCart()
    {
        _addBackpackBtn.Click();
        return this;
    }
}