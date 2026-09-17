using OpenQA.Selenium;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class CheckoutStepTwoPage : BasePage
{
    private Button FinishBtn => new Button(_driver, By.Id("finish"));

    public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
    {
    }
    
    public CheckoutCompletePage FinishCheckout()
    {
        FinishBtn.Click();
        
        return new CheckoutCompletePage(_driver);
    }
}