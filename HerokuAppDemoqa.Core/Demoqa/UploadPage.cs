using OpenQA.Selenium;

namespace HerokuAppDemoqa.Core.Demoqa;

public class UploadPage : BasePage
{
    private readonly By _uploadInput = By.Id("uploadFile");

    private readonly By _uploadedFilePath = By.Id("uploadedFilePath");

    public UploadPage(IWebDriver driver) : base(driver)
    {
    }

    public void OpenPage()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
    }

    public void UploadFile(string absoluteFilePath)
    {
        _driver.FindElement(_uploadInput).SendKeys(absoluteFilePath);
    }

    public string GetUploadedResultText()
    {
        return _driver.FindElement(_uploadedFilePath).Text;
    }
}