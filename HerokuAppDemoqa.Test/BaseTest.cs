using System.IO; // ВАЖНО: Добавляем для работы с папками
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuAppDemoqa.Test;

public class BaseTest
{
    protected IWebDriver driver;
    protected string downloadPath; 

    [SetUp]
    public void Setup()
    {
        downloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestDownloads");
        
        Directory.CreateDirectory(downloadPath);
        
        ChromeOptions options = new ChromeOptions();
        
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        
        driver = new ChromeDriver(options);
        
        driver.Manage().Window.Maximize(); 
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}