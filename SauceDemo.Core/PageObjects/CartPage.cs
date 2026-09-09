using OpenQA.Selenium;

namespace SauceDemo.Core.PageObjects;

public class CartPage : BasePage
{
    #region Locators
    private readonly By _btnCheckout = By.Id("checkout");
    private readonly By _cartItem = By.ClassName("cart_item");
    private readonly By _btnRemoveItem = By.XPath("//button[text()='Remove']");
    #endregion

    // Связь с шапкой в стиле преподавателя
    public HeaderSection Header => new(_driver);

    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    #region Methods
    public void ClickCheckout() => 
        _driver.FindElement(_btnCheckout).Click();

    public int GetCartItemsCount() => 
        _driver.FindElements(_cartItem).Count;

    public void RemoveFirstItem() => 
        _driver.FindElement(_btnRemoveItem).Click();

    public bool IsCartPageDisplayed() => 
        _driver.FindElement(_btnCheckout)?.Displayed ?? false;
    #endregion
}