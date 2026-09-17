using OpenQA.Selenium;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class CartPage : BasePage
{
    #region Elements
    private Button CheckoutBtn => new Button(_driver, By.Id("checkout"));
    private Button RemoveItemBtn => new Button(_driver, By.XPath("//button[text()='Remove']"));
    
    // Оставляем By для FindElements
    private readonly By _cartItem = By.ClassName("cart_item");
    #endregion

    public HeaderSection Header => new(_driver);

    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    #region Methods
    public CheckoutStepOnePage ClickCheckout()
    {
        CheckoutBtn.Click();
        return new CheckoutStepOnePage(_driver);
    }

    public int GetCartItemsCount() => _driver.FindElements(_cartItem).Count;

    public void RemoveFirstItem() => RemoveItemBtn.Click();

    public bool IsCartPageDisplayed() => CheckoutBtn.IsDisplayed();
    #endregion
}