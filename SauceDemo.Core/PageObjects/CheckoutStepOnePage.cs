using OpenQA.Selenium;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class CheckoutStepOnePage : BasePage
{
    private Input FirstNameInput => new Input(_driver, By.Id("first-name"));
    private Input LastNameInput => new Input(_driver, By.Id("last-name"));
    private Input PostalCodeInput => new Input(_driver, By.Id("postal-code"));
    private Button ContinueBtn => new Button(_driver, By.Id("continue"));

    public CheckoutStepOnePage(IWebDriver driver) : base(driver)
    {
    }
    
    public CheckoutStepTwoPage ContinueCheckout(string firstName, string lastName, string postalCode)
    {
        FirstNameInput.SendKeys(firstName);
        LastNameInput.SendKeys(lastName);
        PostalCodeInput.SendKeys(postalCode);
        ContinueBtn.Click();
        
        return new CheckoutStepTwoPage(_driver);
    }
}