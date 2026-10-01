using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using System;
using System.Text.RegularExpressions;

namespace SauceDemo.Test.StepDefinitions;

[Binding]
public class BookingSearchSteps
{
    private IWebDriver _driver = null!;
    private WebDriverWait _wait = null!;
    private IWebElement? _hotelCard; // карточка найденного отеля — нужна для проверки рейтинга

    [BeforeScenario]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    [AfterScenario]
    public void TearDown()
    {
        _driver?.Quit(); // Quit() сам освобождает ресурсы, Dispose не нужен
    }

    [Given(@"I open the Booking search page")]
    public void GivenIOpenTheBookingSearchPage()
    {
        _driver.Navigate().GoToUrl("https://www.booking.com/searchresults.en-gb.html");
        AcceptCookies();
        CloseSignInPopup();
    }

    [When(@"I enter the hotel name ""(.*)""")]
    public void WhenIEnterTheHotelName(string hotelName)
    {
        var searchInput = _wait.Until(d =>
        {
            var el = d.FindElement(By.Name("ss"));
            return el.Displayed && el.Enabled ? el : null;
        });

        // Clear() на React-полях иногда не срабатывает — очищаем через выделение
        searchInput.SendKeys(Keys.Control + "a");
        searchInput.SendKeys(Keys.Command + "a"); // для macOS
        searchInput.SendKeys(Keys.Delete);
        searchInput.SendKeys(hotelName);
    }

    [When(@"I click the Search button")]
    public void WhenIClickTheSearchButton()
    {
        CloseSignInPopup(); // попап может вылезти после ввода

        var searchButton = _wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("button[type='submit']"));
            return el.Displayed && el.Enabled ? el : null;
        });
        searchButton.Click();
    }

    [Then(@"I should see the hotel ""(.*)"" in the search results")]
    public void ThenIShouldSeeTheHotelInTheSearchResults(string hotelName)
    {
        CloseSignInPopup();

        // Ищем именно карточку отеля, в заголовке которой есть нужное название
        var cardXPath =
            $"//div[@data-testid='property-card'][.//div[@data-testid='title' and contains(normalize-space(.), {XPathLiteral(hotelName)})]]";

        try
        {
            _hotelCard = _wait.Until(d => d.FindElement(By.XPath(cardXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail($"Отель \"{hotelName}\" не найден в результатах поиска");
        }

        Assert.That(_hotelCard!.Displayed, Is.True, $"Отель \"{hotelName}\" не отображается на странице");
    }

    [Then(@"the rating for this hotel should be ""(.*)""")]
    public void ThenTheRatingForThisHotelShouldBe(string expectedRating)
    {
        Assert.That(_hotelCard, Is.Not.Null, "Сначала нужно найти карточку отеля");

        // Рейтинг ищем ВНУТРИ карточки нужного отеля, а не по всей странице
        var scoreBlock = _hotelCard!.FindElement(By.CssSelector("[data-testid='review-score']"));

        // Текст вида "Scored 8.7 8.7 Fabulous 1,234 reviews" — берём первое число формата X.X
        var match = Regex.Match(scoreBlock.Text, @"\b\d{1,2}[.,]\d\b");
        Assert.That(match.Success, Is.True, $"Не удалось прочитать рейтинг из текста: \"{scoreBlock.Text}\"");

        var actualRating = match.Value.Replace(',', '.');
        Assert.That(actualRating, Is.EqualTo(expectedRating),
            $"Ожидался рейтинг {expectedRating}, на сайте {actualRating}");
    }

    // ---------- Вспомогательные методы ----------

    private void AcceptCookies()
    {
        try
        {
            var shortWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            shortWait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler"))).Click();
        }
        catch (WebDriverTimeoutException) { /* баннера нет */ }
    }

    private void CloseSignInPopup()
    {
        try
        {
            var shortWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            shortWait.Until(d => d.FindElement(By.CssSelector("button[aria-label='Dismiss sign-in info.']"))).Click();
        }
        catch (WebDriverTimeoutException) { /* попапа нет */ }
    }

    // Безопасно подставляет строку в XPath, даже если в названии есть апостроф
    private static string XPathLiteral(string value)
    {
        if (!value.Contains('\'')) return $"'{value}'";
        if (!value.Contains('"')) return $"\"{value}\"";
        return "concat('" + value.Replace("'", "',\"'\",'") + "')";
    }
}