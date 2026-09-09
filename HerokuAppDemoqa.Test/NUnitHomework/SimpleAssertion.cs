using NUnit.Framework;

namespace HerokuAppDemoqa.Test.NUnitHomework;

public class SimpleAssertion : HooksBaseTest
{
    [TestCase(10, 5, 15)]
    [TestCase(0, 0, 0)]
    [TestCase(-5, 5, 0)]
    public void AdditionTest(int a, int b, int expectedResult)
    {
        Assert.That(a + b, Is.EqualTo(expectedResult));
    }
}