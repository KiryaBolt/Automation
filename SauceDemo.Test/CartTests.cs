using NUnit.Framework;
using SauceDemo.Core.PageObjects;

namespace SauceDemo.Test;

public class CartTests : BaseTest
{
    [Test]
    public void OpenCartTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        
        InventoryPage inventoryPage = loginPage.Login();
        CartPage cartPage = inventoryPage.Header.ClickCart();
        
        Assert.That(cartPage.IsCartPageDisplayed(), Is.True, "Корзина не открылась!");
        Assert.That(cartPage.GetCartItemsCount(), Is.EqualTo(0), "Корзина должна быть пустой!");
    }
    [Test]
    public void CartCheckoutButtonDisplayTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        InventoryPage inventoryPage = loginPage.Login();
        CartPage cartPage = inventoryPage.Header.ClickCart();
        
        Assert.That(cartPage.IsCartPageDisplayed(), Is.True, "Кнопка Checkout не отображается в корзине!");
    }
    [Test]
    public void AddItemAndVerifyInCartTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        InventoryPage inventoryPage = loginPage.Login();
        inventoryPage.AddBackpackToCart();
        CartPage cartPage = inventoryPage.Header.ClickCart();
        
        Assert.That(cartPage.GetCartItemsCount(), Is.EqualTo(1), "Товар не добавился в корзину!");
    }
}