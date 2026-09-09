using NUnit.Framework;
using HerokuAppDemoqa.Core.Demoqa;

namespace HerokuAppDemoqa.Test.Demoqa;

public class ActionsTests : BaseTest
{
    [Test]
    public void DragAndDropTest()
    {
        DroppablePage page = new DroppablePage(driver);
        page.OpenPage();
        
        page.DragAndDropElement();
        
        string actualText = page.GetDropZoneText();
        
        Assert.That(actualText, Is.EqualTo("Dropped!"), "Текст не изменился на Dropped!");
    }
}