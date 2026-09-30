using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class CartPage : BasePage
{
    [FindsBy(How = How.Id, Using = "checkout")]
    private IWebElement _checkoutBtn;

    [FindsBy(How = How.XPath, Using = "//button[text()='Remove']")]
    private IWebElement _removeItemBtn;
    
    [FindsBy(How = How.ClassName, Using = "cart_item")]
    private IList<IWebElement> _cartItems;

    public HeaderSection Header => new HeaderSection(_driver);

    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _checkoutBtn.Displayed);
    }

    public CheckoutStepOnePage ClickCheckout()
    {
        _checkoutBtn.Click();
        return new CheckoutStepOnePage(_driver);
    }

    public int GetCartItemsCount() => _cartItems.Count;

    public CartPage RemoveFirstItem() 
    {
        _removeItemBtn.Click();
        return this;
    }

    public bool IsCartPageDisplayed() => _checkoutBtn.Displayed;
}