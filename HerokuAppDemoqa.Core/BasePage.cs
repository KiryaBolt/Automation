using OpenQA.Selenium;

namespace HerokuAppDemoqa.Core;

public class BasePage
{
    protected IWebDriver _driver;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;
    }
}