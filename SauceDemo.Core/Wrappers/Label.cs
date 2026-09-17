using OpenQA.Selenium;

namespace SauceDemo.Core.Wrappers;

public class Label : BaseElement
{
    public Label(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public string Text => Element.Text;
}