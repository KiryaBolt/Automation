using NUnit.Framework;
using System;

[assembly: Parallelizable(ParallelScope.Fixtures)]

[assembly: LevelOfParallelism(2)]

namespace HerokuAppDemoqa.Test.NUnitHomework;

public class HooksBaseTest
{

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Console.WriteLine($"[OneTimeSetUp] Подготовка для класса: {TestContext.CurrentContext.Test.ClassName}");
    }
    
    [SetUp]
    public void Setup()
    {
        Console.WriteLine($"  [SetUp] Старт теста: {TestContext.CurrentContext.Test.Name}");
    }
    
    [TearDown]
    public void TearDown()
    {
        Console.WriteLine($"  [TearDown] Конец теста: {TestContext.CurrentContext.Test.Name}");
    }
    
    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        Console.WriteLine($"[OneTimeTearDown] Очистка для класса: {TestContext.CurrentContext.Test.ClassName}");
    }
}