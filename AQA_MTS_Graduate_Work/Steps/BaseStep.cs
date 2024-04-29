using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using AQA_MTS_Graduate_Work.Pages.AddtestCasePage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
public class BaseStep(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;

    protected MilestonesPage? MilestonesPage { get; set; }
    protected OwnProjectPage? OwnProjectPage { get; set;}
    protected AddMilestonePage? AddMilestonePage { get; set; }
    protected AddTestCasePage? AddTestCasePage {  get; set; }   
}