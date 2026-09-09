using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HerokuAppDemoqa.Core.Demoqa;

public class DroppablePage : BasePage
{
    private readonly By _dragMe = By.Id("draggable");
    private readonly By _dropHere = By.Id("droppable");

    public DroppablePage(IWebDriver driver) : base(driver)
    {
    }

    public void OpenPage()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/droppable");
    }

    public void DragAndDropElement()
    {
        Actions actions = new Actions(_driver);

        IWebElement source = _driver.FindElement(_dragMe);
        IWebElement target = _driver.FindElement(_dropHere);

        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("window.scrollBy(0, 250);");

        System.Threading.Thread.Sleep(500);

        actions.DragAndDrop(source, target).Perform();
    }

    public string GetDropZoneText()
    {
        return _driver.FindElement(_dropHere).Text;
    }
}


