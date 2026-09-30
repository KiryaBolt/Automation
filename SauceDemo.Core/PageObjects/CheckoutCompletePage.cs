using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class CheckoutCompletePage : BasePage
{
    [FindsBy(How = How.ClassName, Using = "complete-header")]
    private IWebElement _completeMessage;

    public CheckoutCompletePage(IWebDriver driver) : base(driver)
    {
    }
    
    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _completeMessage.Displayed);
    }

    public string GetCompleteMessageText()
    {
        return _completeMessage.Text;
    }
}