using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

public class BaseTest
{
    protected IWebDriver driver;

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