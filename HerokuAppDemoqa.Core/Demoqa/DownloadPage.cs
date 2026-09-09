using OpenQA.Selenium;

namespace HerokuAppDemoqa.Core.Demoqa;

public class DownloadPage : BasePage
{
    private readonly By _downloadButton = By.Id("downloadButton");
    
    public DownloadPage(IWebDriver driver) : base(driver)
    {
    }
    
    public void OpenPage()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
    }

    public void ClickDownload()
    {
        _driver.FindElement(_downloadButton).Click();
    }
}