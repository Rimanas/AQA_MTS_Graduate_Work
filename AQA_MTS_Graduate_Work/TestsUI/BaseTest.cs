using AQA_MTS_Graduate_Work.Core;
using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Helpers;
using AQA_MTS_Graduate_Work.Steps;
using OpenQA.Selenium;
using Allure.NUnit;
using Allure.Net.Commons;
using System.Text;

namespace AQA_MTS_Graduate_Work.TestsUI;
[Parallelizable(scope: ParallelScope.Fixtures)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    protected LoginSteps LoginSteps;
    protected DashboardStep DashboardStep;
    protected ProjectSteps ProjectSteps;
    protected MilestoneSteps _milestoneSteps;
    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [SetUp]
    public void FactoryDriverTest()
    {
        Driver = new Browser().Driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        LoginSteps = new LoginSteps(Driver);
        DashboardStep = new DashboardStep(Driver);
        ProjectSteps = new ProjectSteps(Driver);
        _milestoneSteps = new MilestoneSteps(Driver);

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
                AllureApi.AddAttachment("error.txt", "text/plain", Encoding.UTF8.GetBytes(TestContext.CurrentContext.Result.Message));
            }
        }

        finally
        {
            Driver.Quit();
        }
    }
}