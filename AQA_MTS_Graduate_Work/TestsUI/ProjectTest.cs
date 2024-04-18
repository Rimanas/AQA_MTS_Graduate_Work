using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using AQA_MTS_Graduate_Work.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_MTS_Graduate_Work.TestsUI;
    public class ProjectTest : BaseTest
{

    [Test]
    [Description("Проверка Открытия страницы Добавления проекта")]

    public void AddProjectPageOpenTest()
    {
        AddProjectPage addProjectPage = new AddProjectPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);      
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickAddProjectBtn();
        Assert.That(addProjectPage.IsPageOpened);
    }

    [Test]
    [Description("Проверка Добавления проекта")]

    public void AddProjectTest()
    {
        string expectedText = "Successfully added the new project.";
        //ProjectSteps projectSteps = new ProjectSteps(Driver);
        ProjectsPage projectsPage = new ProjectsPage(Driver);
        AddProjectPage addProjectPage = new AddProjectPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickAddProjectBtn();
        addProjectPage.InputFieldName.SendKeys("AutoProject");
        Thread.Sleep(4000);
        addProjectPage.ClickAddButton();
        //projectsPage = projectSteps.AddProject("AutoProject");
        Assert.That(projectsPage.IsPageOpened);
        Assert.That(projectsPage.GetSuccessAddProjectLabel, Is.EqualTo(expectedText));

    }
}
