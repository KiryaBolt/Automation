using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SauceDemo.Core.Configuration;
using System;

namespace SauceDemo.Core.Infrastructure;

public static class DriverFactory
{
    public static IWebDriver CreateDriver(TestSettings settings)
    {
        IWebDriver driver = settings.BrowserType.ToLower() switch
        {
            "chrome" => GetChromeDriver(settings.IsHeadless),
            "firefox" => GetFirefoxDriver(settings.IsHeadless),
            _ => throw new ArgumentException($"Браузер '{settings.BrowserType}' не поддерживается.")
        };

        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(settings.ImplicitWaitTimeout);
        
        return driver;
    }

    private static IWebDriver GetChromeDriver(bool isHeadless)
    {
        var options = new ChromeOptions();
        if (isHeadless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox"); // Отключение песочницы для Docker
            options.AddArgument("--disable-dev-shm-usage"); // Обход ограничений памяти в Docker
            options.BinaryLocation = "/usr/bin/chromium"; // Путь к браузеру внутри Linux-контейнера
        }
    
        return new ChromeDriver(options);
    }

    private static IWebDriver GetFirefoxDriver(bool isHeadless)
    {
        var options = new FirefoxOptions();
        if (isHeadless) options.AddArgument("--headless");
        return new FirefoxDriver(options);
    }
}