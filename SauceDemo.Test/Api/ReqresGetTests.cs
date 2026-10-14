using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using SauceDemo.Core.Api;
using SauceDemo.Core.Api.Models;

namespace SauceDemo.Test.Api;

[TestFixture]
[Category("API")]
public class ReqresGetTests : ApiTestBase
{
    [Test]
    public async Task GetUsersList_Page2_ReturnsUsers()
    {
        var response = await Api.GetAsync("users?page=2");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<ListResponse<ReqresUser>>(response);
        Assert.Multiple(() =>
        {
            Assert.That(body.Page, Is.EqualTo(2));
            Assert.That(body.Data, Has.Count.EqualTo(body.PerPage));
            Assert.That(body.Data, Has.All.Matches<ReqresUser>(u => u.Id > 0 && u.Email.Contains('@')));
        });
    }

    [Test]
    public async Task GetSingleUser_ExistingId_ReturnsUser()
    {
        var response = await Api.GetAsync("users/2");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var user = (await ReqresClient.ReadAsync<SingleResponse<ReqresUser>>(response)).Data;
        Assert.Multiple(() =>
        {
            Assert.That(user.Id, Is.EqualTo(2));
            Assert.That(user.Email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(user.FirstName, Is.EqualTo("Janet"));
        });
    }

    [Test]
    [Category("Negative")]
    public async Task GetSingleUser_NotExistingId_Returns404()
    {
        var response = await Api.GetAsync("users/23");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetResourcesList_ReturnsResources()
    {
        var response = await Api.GetAsync("unknown");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<ListResponse<ReqresResource>>(response);
        Assert.That(body.Data, Is.Not.Empty);
        Assert.That(body.Data, Has.All.Matches<ReqresResource>(r => r.Year > 0 && r.Color.StartsWith('#')));
    }

    [Test]
    public async Task GetSingleResource_ExistingId_ReturnsResource()
    {
        var response = await Api.GetAsync("unknown/2");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var resource = (await ReqresClient.ReadAsync<SingleResponse<ReqresResource>>(response)).Data;
        Assert.Multiple(() =>
        {
            Assert.That(resource.Id, Is.EqualTo(2));
            Assert.That(resource.Name, Is.EqualTo("fuchsia rose"));
        });
    }

    [Test]
    [Category("Negative")]
    public async Task GetSingleResource_NotExistingId_Returns404()
    {
        var response = await Api.GetAsync("unknown/23");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetUsers_WithDelay_RespondsAfterDelay()
    {
        var stopwatch = Stopwatch.StartNew();
        var response = await Api.GetAsync("users?delay=2");
        stopwatch.Stop();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(stopwatch.Elapsed.TotalSeconds, Is.GreaterThanOrEqualTo(2));
    }

    [Test]
    [Category("Negative")]
    public async Task GetUsersList_PageOutOfRange_ReturnsEmptyData()
    {
        var response = await Api.GetAsync("users?page=100");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<ListResponse<ReqresUser>>(response);
        Assert.Multiple(() =>
        {
            Assert.That(body.Page, Is.EqualTo(100));
            Assert.That(body.Data, Is.Empty);
        });
    }
}