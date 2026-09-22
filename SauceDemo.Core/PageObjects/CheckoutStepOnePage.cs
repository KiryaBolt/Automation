using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Core.PageObjects;

public class CheckoutStepOnePage : BasePage
{
    [FindsBy(How = How.Id, Using = "first-name")]
    private IWebElement _firstNameInput;

    [FindsBy(How = How.Id, Using = "last-name")]
    private IWebElement _lastNameInput;

    [FindsBy(How = How.Id, Using = "postal-code")]
    private IWebElement _postalCodeInput;

    [FindsBy(How = How.Id, Using = "continue")]
    private IWebElement _continueBtn;

    public CheckoutStepOnePage(IWebDriver driver) : base(driver)
    {
    }

    protected override void WaitForPageLoad()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => _continueBtn.Displayed);
    }
    
    public CheckoutStepOnePage SetFirstName(string firstName)
    {
        _firstNameInput.SendKeys(firstName);
        return this;
    }

    public CheckoutStepOnePage SetLastName(string lastName)
    {
        _lastNameInput.SendKeys(lastName);
        return this;
    }

    public CheckoutStepOnePage SetPostalCode(string postalCode)
    {
        _postalCodeInput.SendKeys(postalCode);
        return this;
    }

    public CheckoutStepTwoPage ClickContinue()
    {
        _continueBtn.Click();
        return new CheckoutStepTwoPage(_driver);
    }
    
    public CheckoutStepTwoPage ContinueCheckout(string firstName, string lastName, string postalCode)
    {
        return SetFirstName(firstName)
            .SetLastName(lastName)
            .SetPostalCode(postalCode)
            .ClickContinue();
    }
}