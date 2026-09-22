using OpenQA.Selenium;

namespace SauceDemo.Core.PageObjects;

public class BasePage
{
    protected IWebDriver _driver;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void OpenSauceDemo()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _driver.Manage().Window.Maximize();
    }
    
    public string GetUrl()
    {
        return _driver.Url;
    }
    
    public string GetPageTitle()
    {
        return _driver.Title;
    }
}
