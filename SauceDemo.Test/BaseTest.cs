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
        var options = new ChromeOptions();
        options.AddArgument("--headless=new"); 
        options.AddArgument("--no-sandbox"); 
        options.AddArgument("--disable-dev-shm-usage"); 
        options.BinaryLocation = "/usr/bin/chromium";

        driver = new ChromeDriver(options);
    
        new BasePage(driver).OpenSauceDemo();
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
} 