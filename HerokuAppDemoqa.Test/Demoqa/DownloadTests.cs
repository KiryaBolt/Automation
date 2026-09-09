using NUnit.Framework;
using HerokuAppDemoqa.Core.Demoqa;
using System.IO;
using System.Threading;

namespace HerokuAppDemoqa.Test.Demoqa;

public class DownloadTests : BaseTest
{
    [Test]
    public void FileDownloadTest()
    {
        DownloadPage page = new DownloadPage(driver);
        page.OpenPage();

        string expectedFileName = "sampleFile.jpeg";

        string expectedFilePath = Path.Combine(downloadPath, expectedFileName);

        if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }

        page.ClickDownload();

        bool isFileDownloaded = false;

        for (int i = 0; i < 10; i++)
        {
            if (File.Exists(expectedFilePath))
            {
                isFileDownloaded = true;
                break;
            }

            Thread.Sleep(500);
        }

        Assert.That(isFileDownloaded, Is.True, "Файл не скачался в нужную папку!");
    }
}