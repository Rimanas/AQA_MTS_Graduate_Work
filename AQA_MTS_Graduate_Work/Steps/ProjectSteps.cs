using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
   public class ProjectSteps : BaseStep
{
    private AddProjectPage _addProjectPage;
    private DashboardPage _dashboardPage;   

    public ProjectSteps(IWebDriver driver) : base(driver)
    {
        _addProjectPage = new AddProjectPage(Driver);
        //_addProjectPage = new DashboardPage(Driver);
    }
    public ProjectsPage AddProject(string projectName)
    {
        _dashboardPage.ClickAddProjectBtn();
        _addProjectPage.InputFieldName.SendKeys(projectName);
        _addProjectPage.ClickAddButton();

        return new ProjectsPage(Driver);
    }
}
