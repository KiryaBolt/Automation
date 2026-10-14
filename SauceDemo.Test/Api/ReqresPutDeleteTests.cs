using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using SauceDemo.Core.Api;
using SauceDemo.Core.Api.Models;

namespace SauceDemo.Test.Api;

[TestFixture]
[Category("API")]
public class ReqresPutDeleteTests : ApiTestBase
{
    [Test]
    public async Task UpdateUser_Put_ReturnsUpdatedUser()
    {
        var request = new UserRequest { Name = "morpheus", Job = "zion resident" };

        var response = await Api.PutAsync("users/2", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<UpdateUserResponse>(response);
        Assert.Multiple(() =>
        {
            Assert.That(body.Name, Is.EqualTo(request.Name));
            Assert.That(body.Job, Is.EqualTo(request.Job));
            Assert.That(body.UpdatedAt, Is.Not.Null);
        });
    }

    [Test]
    public async Task UpdateUser_Patch_ReturnsUpdatedJob()
    {
        var request = new UserRequest { Job = "senior zion resident" };

        var response = await Api.PatchAsync("users/2", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReqresClient.ReadAsync<UpdateUserResponse>(response);
        Assert.Multiple(() =>
        {
            Assert.That(body.Job, Is.EqualTo(request.Job));
            Assert.That(body.UpdatedAt, Is.Not.Null);
        });
    }

    [Test]
    public async Task DeleteUser_Returns204WithEmptyBody()
    {
        var response = await Api.DeleteAsync("users/2");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.Empty);
    }
}