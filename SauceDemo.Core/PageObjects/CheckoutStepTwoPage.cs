using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class CheckoutStepTwoPage : BasePage
{
    [FindsBy(How = How.Id, Using = "finish")]
    private IWebElement _finishBtn;

    public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
    {
    }
    
    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _finishBtn.Displayed);
    }

    public CheckoutCompletePage FinishCheckout()
    {
        _finishBtn.Click();
        return new CheckoutCompletePage(_driver);
    }
}