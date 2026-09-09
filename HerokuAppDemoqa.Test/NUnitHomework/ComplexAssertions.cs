using NUnit.Framework;
using System.Collections.Generic;

namespace HerokuAppDemoqa.Test.NUnitHomework;

public class ComplexAssertions : HooksBaseTest
{
    public static IEnumerable<TestCaseData> StringTestData()
    {
        yield return new TestCaseData("hello", "HELLO");
        yield return new TestCaseData("automation", "AUTOMATION");
    }
    
    [TestCaseSource(nameof(StringTestData))]
    public void StringToUpperTest(string word, string expectedWord)
    {
        Assert.That(word.ToUpper(), Is.EqualTo(expectedWord));
    }
}