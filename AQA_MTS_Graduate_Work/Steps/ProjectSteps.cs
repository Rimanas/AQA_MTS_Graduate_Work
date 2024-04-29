using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
   public class ProjectSteps : BaseStep
{
    private AddProjectPage _addProjectPage; 

    public ProjectSteps(IWebDriver driver) : base(driver)
    {
        _addProjectPage = new AddProjectPage(Driver);
    }
    [AllureStep]
    public ProjectsPage AddProject(string projectName)
    {
        _addProjectPage.InputFieldName.SendKeys(projectName);
        Thread.Sleep(4000);
        _addProjectPage.ClickAddButton();

        return new ProjectsPage(Driver);
    }
}
