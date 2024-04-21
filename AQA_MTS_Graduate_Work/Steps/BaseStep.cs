using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
public class BaseStep
{
    protected IWebDriver Driver;

    public BaseStep(IWebDriver driver)
    {
        Driver = driver;
    }
    protected MilestonesPage? MilestonesPage { get; set; }
}