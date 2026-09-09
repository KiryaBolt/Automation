using NUnit.Framework;
using HerokuAppDemoqa.Core;

namespace HerokuAppDemoqa.Test;

public class DynamicControlsTests : BaseTest
{
    [Test]
    public void DynamicControlsFlowTest()
    {
        DynamicControlsPage page = new DynamicControlsPage(driver);
        page.OpenPage();

        page.ClickRemoveButton();

        string text1 = page.WaitAndGetMessageText();
        Assert.That(text1, Is.EqualTo("It's gone!"));

        Assert.That(page.IsCheckboxPresent(), Is.False);

        Assert.That(page.IsInputEnabled(), Is.False);

        page.ClickEnableButton();

        string text2 = page.WaitAndGetMessageText();
        Assert.That(text2, Is.EqualTo("It's enabled!"));

        Assert.That(page.IsInputEnabled(), Is.True);
    }
}