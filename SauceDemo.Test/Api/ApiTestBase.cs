using System;
using NUnit.Framework;
using SauceDemo.Core.Api;

namespace SauceDemo.Test.Api;

public abstract class ApiTestBase
{
    protected const string ApiKeyEnvVar = "REQRES_API_KEY";

    protected ReqresClient Api = null!;

    [OneTimeSetUp]
    public void ApiOneTimeSetUp()
    {
        var apiKey = Environment.GetEnvironmentVariable(ApiKeyEnvVar);
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Assert.Fail($"Не задана переменная окружения {ApiKeyEnvVar}. " +
                        "Бесплатный ключ: https://app.reqres.in/api-keys");
        }

        Api = new ReqresClient(apiKey);
    }

    [OneTimeTearDown]
    public void ApiOneTimeTearDown() => Api?.Dispose();
}