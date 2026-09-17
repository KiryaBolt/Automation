using OpenQA.Selenium;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class InventoryPage : BasePage
{
    #region Elements

    private Button CartIcon => new Button(_driver, By.CssSelector("a[data-test='shopping-cart-link']"));
    private Button AddBackpackBtn => new Button(_driver, By.Id("add-to-cart-sauce-labs-backpack"));
    #endregion

    public HeaderSection Header => new (_driver);

    public InventoryPage(IWebDriver driver) : base(driver)
    {
    }

    #region Methods
    public bool IsCartIconDisplayed()
    {
        // Вызываем метод IsDisplayed(), который унаследован от BaseElement
        return CartIcon.IsDisplayed();
    }

    public void AddBackpackToCart()
    {
        // Метод Click() берем из обертки Button
        AddBackpackBtn.Click();
    }
    #endregion
}