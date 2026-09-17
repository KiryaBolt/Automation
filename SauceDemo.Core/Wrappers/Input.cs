using OpenQA.Selenium;

namespace SauceDemo.Core.Wrappers;

public class Input : BaseElement
{
    public Input(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public void SendKeys(string text)
    {
        Element.Clear(); // Хорошая практика - очищать поле перед вводом
        Element.SendKeys(text);
    }
}