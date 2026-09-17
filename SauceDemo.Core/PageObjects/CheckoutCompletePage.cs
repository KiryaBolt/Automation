using OpenQA.Selenium;
using SauceDemo.Core.Wrappers;

namespace SauceDemo.Core.PageObjects;

public class CheckoutCompletePage : BasePage
{
    private Label CompleteMessage => new Label(_driver, By.ClassName("complete-header"));

    public CheckoutCompletePage(IWebDriver driver) : base(driver)
    {
    }
    
    public string GetCompleteMessageText()
    {
        return CompleteMessage.Text;
    }
}