using OpenQA.Selenium;

namespace SauceDemo.Core.PageObjects;

public class InventoryPage : BasePage
{
    #region Locators
    private readonly By imgCart = By.CssSelector("a[data-test='shopping-cart-link']");
    
    private readonly By _btnAddBackpack = By.Id("add-to-cart-sauce-labs-backpack");
    #endregion

    public HeaderSection Header => new (_driver);

    public InventoryPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    #region Methods
    public bool IsCartIconDisplayed()
    {
        return _driver.FindElement(imgCart)?.Displayed ?? false;
    }
    
    public void AddBackpackToCart()
    {
        _driver.FindElement(_btnAddBackpack).Click();
    }
    #endregion
}