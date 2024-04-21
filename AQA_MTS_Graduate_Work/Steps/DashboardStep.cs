using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AQA_MTS_Graduate_Work.Steps;
    public class DashboardStep : BaseStep
{
    private DashboardPage _dashboardPage;

    public DashboardStep(IWebDriver driver) : base(driver)
    {
        _dashboardPage = new DashboardPage(Driver);
    }

    // Комплексные  
    public void MouseHoverBird()
    {
        Actions actions = new Actions(Driver);
        actions
            .MoveToElement(_dashboardPage.IconTwitter)
            .Build()
            .Perform();
    }
}