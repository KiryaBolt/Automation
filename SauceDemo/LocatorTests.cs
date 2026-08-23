using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

// Создать новый класс, в нем для ресурса https://www.saucedemo.com/ составить
// список локаторов, можно искать на ВСЕХ страницах приложения
// (driver.findWebElement(<локатор>)) для КАЖДОГО из примеров локаторов
// ниже:
// ● id
// ● name
// ● classname
// ● tagname
// ● linktext
// ● partiallinktext
// ● xpath
// ○ Поиск по атрибуту, например By.xpath("//tag[@attribute='value']");
// ○ Поиск по тексту, например By.xpath("//tag[text()='text']");
// ○ Поиск по частичному совпадению атрибута, например By.xpath("//tag[contains(@attribute,'text')]");
// ○ Поиск по частичному совпадению текста, например By.xpath("//tag[contains(text(),'text')]");
// ○ ancestor, например //*[text()='Enterprise Testing']//ancestor::div
// ○ descendant
// ○ following
// ○ parent
// ○ preceding
// ○ *поиск элемента с условием AND, например //input[@class='_2zrpKA _1dBPDZ' and @type='text']

// ● css
// ○ .class
// ○ .class1.class2
// ○ .class1 .class2
// ○ #id
// ○ tagname
// ○ tagname.class
// ○ [attribute=value]
// ○ [attribute~=value]
// ○ [attribute|=value]
// ○ [attribute^=value]
// ○ [attribute$=value]
// ○ [attribute*=value]

namespace SauceDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LocatorTests()
    {
        using var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        
        var byId = driver.FindElement(By.Id("user-name"));
        var byName = driver.FindElement(By.Name("password"));
        var byClassName = driver.FindElement(By.ClassName("submit-button"));
        var byTagName = driver.FindElement(By.TagName("input"));
        var byLinkText = driver.FindElement(By.LinkText("Twitter"));
        var byPartialLinkText = driver.FindElement(By.PartialLinkText("Twit"));

        var xpAttribute = driver.FindElement(By.XPath("//input[@data-test='username']"));
        var xpText = driver.FindElement(By.XPath("//div[text()='Swag Labs']"));
        var xpContainsAttr = driver.FindElement(By.XPath("//input[contains(@class, 'btn')]"));
        var xpContainsText = driver.FindElement(By.XPath("//div[contains(text(), 'Swag')]"));

        var xpAncestor = driver.FindElement(By.XPath("//*[text()='Swag Labs']//ancestor::div"));
        var xpDescendant = driver.FindElement(By.XPath("//form//descendant::input[1]"));
        var xpFollowing = driver.FindElement(By.XPath("//input[@id='user-name']//following::input[1]"));
        var xpParent = driver.FindElement(By.XPath("//input[@id='user-name']//parent::div"));
        var xpPreceding = driver.FindElement(By.XPath("//input[@id='password']//preceding::input[1]"));
        var xpAnd = driver.FindElement(By.XPath("//input[@class='input_error form_input' and @type='text']"));

        var cssClass = driver.FindElement(By.CssSelector(".submit-button"));
        var cssMultiClass = driver.FindElement(By.CssSelector(".input_error.form_input"));
        var cssNestedClass = driver.FindElement(By.CssSelector(".login_wrapper .form_group"));
        var cssId = driver.FindElement(By.CssSelector("#user-name"));
        var cssTag = driver.FindElement(By.CssSelector("input"));
        var cssTagClass = driver.FindElement(By.CssSelector("input.submit-button"));
        var cssAttrEqual = driver.FindElement(By.CssSelector("[data-test='username']"));
        var cssAttrWord = driver.FindElement(By.CssSelector("[class~='form_input']"));
        var cssAttrHyphen = driver.FindElement(By.CssSelector("[class|='btn']"));
        var cssAttrStart = driver.FindElement(By.CssSelector("[data-test^='user']"));
        var cssAttrEnd = driver.FindElement(By.CssSelector("[data-test$='name']"));
        var cssAttrContains = driver.FindElement(By.CssSelector("[data-test*='user']"));
    }
}