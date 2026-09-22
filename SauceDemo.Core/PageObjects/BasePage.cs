using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SauceDemo.Core.PageObjects;

public abstract class BasePage 
{
    protected IWebDriver _driver;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;

        PageFactory.InitElements(_driver, this);

        WaitForPageLoad();
    }
    
    protected abstract void WaitForPageLoad();

    public string GetUrl()
    {
        return _driver.Url;
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }
}
