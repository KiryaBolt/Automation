using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemo.Core.Wrappers;

public abstract class BaseElement
{
    protected readonly IWebDriver _driver;
    protected readonly By _locator;

    protected BaseElement(IWebDriver driver, By locator)
    {
        _driver = driver;
        _locator = locator;
    }

    protected IWebElement Element
    {
        get
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.FindElement(_locator));
        }
    }

    public bool IsDisplayed()
    {
        try
        {
            return Element.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}