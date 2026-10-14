using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using SauceDemo.Core.Api;
using SauceDemo.Core.Api.Models;

namespace SauceDemo.Test.Api;

[TestFixture]
[Category("API")]
public class ReqresPostTests : ApiTestBase
{
    [Test]
    public async Task CreateUser_ValidData_Returns201()
    {
        var request = new UserRequest { Name = "morpheus", Job = "leader" };

        var response = await Api.PostAsync("users", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        var body = await ReqresClient.ReadAsync<CreateUserResponse>(response);
        Assert.Multiple(() =>
        {
            Assert.That(body.Name, Is.EqualTo(request.Name));
            Assert.That(body.Job, Is.EqualTo(request.Job));
            Assert.That(body.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(body.CreatedAt, Is.Not.Null);
        });
    }

    [Test]
    public async Task Register_ValidData_ReturnsToken()
    {
        var request = new AuthRequest { Email = "eve.holt@reqres.in", Password = "pistol" };

        var response = await Api.PostAsync("register", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<RegisterResponse>(response);
        Assert.Multiple(() =>
        {
            Assert.That(body.Id, Is.EqualTo(4));
            Assert.That(body.Token, Is.Not.Empty);
        });
    }

    [Test]
    [Category("Negative")]
    public async Task Register_WithoutPassword_Returns400()
    {
        var request = new AuthRequest { Email = "sydney@fife" };

        var response = await Api.PostAsync("register", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await ReqresClient.ReadAsync<ErrorResponse>(response);
        Assert.That(body.Error, Is.EqualTo("Missing password"));
    }

    [Test]
    public async Task Login_ValidCredentials_ReturnsToken()
    {
        var request = new AuthRequest { Email = "eve.holt@reqres.in", Password = "cityslicka" };

        var response = await Api.PostAsync("login", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<LoginResponse>(response);
        Assert.That(body.Token, Is.Not.Empty);
    }

    [Test]
    [Category("Negative")]
    public async Task Login_WithoutPassword_Returns400()
    {
        var request = new AuthRequest { Email = "peter@klaven" };

        var response = await Api.PostAsync("login", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await ReqresClient.ReadAsync<ErrorResponse>(response);
        Assert.That(body.Error, Is.EqualTo("Missing password"));
    }
}