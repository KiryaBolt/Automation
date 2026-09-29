using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Core.Configuration;
using SauceDemo.Core.Infrastructure;

namespace SauceDemo.Test;

public class BaseTest
{
    protected IWebDriver driver;
    protected TestSettings Settings;

    [SetUp]
    public void Setup()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        Settings = new TestSettings();
        config.GetSection("TestSettings").Bind(Settings);

        driver = DriverFactory.CreateDriver(Settings);

        driver.Navigate().GoToUrl(Settings.BaseUrl);
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}