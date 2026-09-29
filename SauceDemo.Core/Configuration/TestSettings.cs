namespace SauceDemo.Core.Configuration;

public class TestSettings
{
    public string BrowserType { get; set; } = "Chrome";
    public string BaseUrl { get; set; } = "https://www.saucedemo.com/";
    public int ImplicitWaitTimeout { get; set; } = 5;
    public bool IsHeadless { get; set; } = false;
}