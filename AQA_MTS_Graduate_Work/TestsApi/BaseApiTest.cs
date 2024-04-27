using Allure.NUnit;
using AQA_MTS_Graduate_Work.Clients;
using AQA_MTS_Graduate_Work.Services;
using NLog;

namespace AQA_MTS_Graduate_Work.TestsApi;

//[Parallelizable(scope: ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectServices? ProjectServices;
    protected MilestoneServices? MilestoneServices;
    protected SectionServices? SectionServices;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectServices = new ProjectServices(restClient);
        MilestoneServices = new MilestoneServices(restClient);
        SectionServices = new SectionServices(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectServices.Dispose();
        MilestoneServices.Dispose();
        SectionServices?.Dispose();
    }
}