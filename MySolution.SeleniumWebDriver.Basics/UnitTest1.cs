using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MySolution.SeleniumWebDriver;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

        var addButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));
        Thread.Sleep(1000);

        addButton.Click();
        Thread.Sleep(1000);
        addButton.Click();
        Thread.Sleep(1000);

        var deleteButtons = driver.FindElements(By.XPath("//button[text()='Delete']"));
        Assert.That(deleteButtons.Count, Is.EqualTo(2));
        Thread.Sleep(1000);

        deleteButtons[0].Click();
        Thread.Sleep(1000);

        deleteButtons = driver.FindElements(By.XPath("//button[text()='Delete']"));
        Thread.Sleep(1000);

        Assert.That(deleteButtons.Count, Is.EqualTo(1));
        Thread.Sleep(1000);
        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

        var checkboxes = driver.FindElements(By.CssSelector("[type=checkbox]"));
        Thread.Sleep(1000);

        Assert.That(checkboxes[0].Selected, Is.False);

        checkboxes[0].Click();
        Thread.Sleep(1000);

        Assert.That(checkboxes[0].Selected, Is.True);
        Assert.That(checkboxes[1].Selected, Is.True);

        checkboxes[1].Click();
        Thread.Sleep(1000);

        Assert.That(checkboxes[1].Selected, Is.False);
        Thread.Sleep(1000);

        Assert.Pass();
    }

    [Test]
    public void Test3()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

        var dropdown = driver.FindElement(By.Id("dropdown"));
        var options = dropdown.FindElements(By.TagName("option"));
        Assert.That(options.Count, Is.EqualTo(3));

        options[1].Click();
        Thread.Sleep(1000);
        Assert.That(options[1].Selected, Is.True);

        options[2].Click();
        Thread.Sleep(1000);
        Assert.That(options[2].Selected, Is.True);

        Assert.Pass();
    }

    [Test]
    public void Test4()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/inputs");

        var input = driver.FindElement(By.TagName("input"));
        input.SendKeys("5");
        Thread.Sleep(1000);
        Assert.That(input.GetAttribute("value"), Is.EqualTo("5"));

        input.SendKeys(Keys.ArrowUp);
        Assert.That(input.GetAttribute("value"), Is.EqualTo("6"));
        Thread.Sleep(1000);

        input.SendKeys(Keys.ArrowDown);
        Assert.That(input.GetAttribute("value"), Is.EqualTo("5"));
        Thread.Sleep(1000);

        input.Clear();
        Thread.Sleep(1000);

        input.SendKeys("abc!@#$$%^&&*");
        Assert.That(input.GetAttribute("value"), Is.EqualTo(""));
        Thread.Sleep(1000);

        Assert.Pass();
    }

    [Test]
    public void Test5()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");

        var cell1 = driver.FindElement(By.XPath("//table[1]//tbody/tr[1]/td[1]"));
        Assert.That(cell1.Text, Is.EqualTo("Smith"));
        Thread.Sleep(1000);

        var cell2 = driver.FindElement(By.XPath("//table[1]//tbody/tr[2]/td[2]"));
        Assert.That(cell2.Text, Is.EqualTo("Frank"));
        Thread.Sleep(1000);

        var cell3 = driver.FindElement(By.XPath("//table[1]//tbody/tr[3]/td[3]"));
        Assert.That(cell3.Text, Is.EqualTo("jdoe@hotmail.com"));
        Thread.Sleep(1000);

        Assert.Pass();
    }

    [Test]
    public void Test6()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/typos");
        Thread.Sleep(1000);

        var paragraphs = driver.FindElements(By.TagName("p"));
        var actualText = paragraphs[1].Text;
        var expectedTest = "Sometimes you'll see a typo, other times you won't.";
        Assert.That(actualText, Is.EqualTo(expectedTest));

        Assert.Pass();
    }

    [Test]
    public void Test8()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/notification_message_rendered");

        var clickHereLink = driver.FindElement(By.LinkText("Click here"));
        clickHereLink.Click();
        Thread.Sleep(1000);

        // 3. Находим всплывающую плашку нотификации по ID
        var notification = driver.FindElement(By.Id("flash"));

        // 4. Забираем текст из нотификации
        var notificationText = notification.Text;

        // 5. Проверяем, что текст содержит одно из ожидаемых сообщений
        Assert.That(notificationText,
            Does.Contain("Action successful").Or.Contains("Action unsuccesful, please try again"));

        Assert.Pass();
    }
}