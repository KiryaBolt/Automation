using OpenQA.Selenium;

namespace SauceDemo.Core.Wrappers;

public class Button : BaseElement
{
    public Button(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public void Click()
    {
        Element.Click();
    }
}