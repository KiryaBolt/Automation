using NUnit.Framework;
using HerokuAppDemoqa.Core.Demoqa;
using System.IO;
using System;

namespace HerokuAppDemoqa.Test.Demoqa;

public class UploadTests : BaseTest
{
    [Test]
    public void FileUploadTest()
    {
        string fileName = "my_test_file.txt";

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

        File.WriteAllText(filePath, "Hello, this is a test file!");

        UploadPage page = new UploadPage(driver);
        page.OpenPage();

        page.UploadFile(filePath);

        string actualText = page.GetUploadedResultText();

        Assert.That(actualText, Does.Contain(fileName), "Имя файла не совпадает с загруженным!");
    }
}