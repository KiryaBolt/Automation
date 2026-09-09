using NUnit.Framework;
using OpenQA.Selenium.Chrome;
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
        var driver = new ChromeDriver();
        Assert.Pass();
    }
}