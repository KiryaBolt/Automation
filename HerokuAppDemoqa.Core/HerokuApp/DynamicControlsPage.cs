using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuAppDemoqa.Core;

public class DynamicControlsPage : BasePage
{
    #region Locators
    private readonly By _checkbox = By.Id("checkbox");
    private readonly By _btnRemove = By.XPath("//button[text()='Remove']");
    private readonly By _inputField = By.CssSelector("#input-example input");
    private readonly By _btnEnable = By.XPath("//button[text()='Enable']");
    private readonly By _message = By.Id("message");
    #endregion
    
    public DynamicControlsPage(IWebDriver driver) : base(driver)
    {
    }
    
    public void OpenPage()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
    }

    public void ClickRemoveButton()
    {
        _driver.FindElement(_btnRemove).Click();
    }

    public bool IsCheckboxPresent()
    {
        return _driver.FindElements(_checkbox).Count > 0;
    }

    public void ClickEnableButton()
    {
        _driver.FindElement(_btnEnable).Click();
    }

    public bool IsInputEnabled()
    {
        return _driver.FindElement(_inputField).Enabled;
    }

    public string WaitAndGetMessageText()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(_message).Displayed);
        
        return _driver.FindElement(_message).Text;
    }
}