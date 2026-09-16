using Allure.NUnit;
using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; // Она уберет красноту с ChromeOptions
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace HerokuAppDemoqa.Test;
[AllureNUnit]

public class BaseTest
{
    protected IWebDriver driver;
    // ВОТ ОНА! Возвращаем нашу коробку для пути загрузок
    protected string downloadPath; 
    
    protected static readonly ILog Log = LogManager.GetLogger(typeof(BaseTest));

    [SetUp]
    public void Setup()
    {
        Log.Info("==== ЗАПУСК НОВОГО ТЕСТА ====");
        
        // --- Настройки скачивания файлов ---
        downloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestDownloads");
        Directory.CreateDirectory(downloadPath);
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        // ------------------------------------

        Log.Info("Открываем браузер Chrome...");
        driver = new ChromeDriver(options); // Отдаем настройки Хрому
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Log.Info("Закрываем браузер...");
        driver.Quit();
        driver.Dispose();
        Log.Info("==== ТЕСТ ЗАВЕРШЕН ====\n");
    }
}