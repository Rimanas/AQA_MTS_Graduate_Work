using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Models;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.TestsUI;

[AllureSuite("UI Tests")]
public class MilestoneTest : BaseTest
{

    [Test]
    [Order(1)]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка Добавления Milestone")]
    [AllureOwner("Qa A")]
    public void AddMilestoneTest()
    {
        string expectedText = "Successfully added the new milestone.";

        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Milestone expectedMilestone = new Milestone()
        {
            //Name = "AutoMilestone",
            Name = dashboardPage.GetLinkOfProject(),
            Description = dashboardPage.GetLinkOfProject(), 
        };
        var milestonesPage = _milestoneSteps.AddMilestone(expectedMilestone);
        string text = milestonesPage.GetSuccessAddMilestoneLabel();
        Assert.That(text, Is.EqualTo(expectedText));
    }

    [Test]
    [Order(2)]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка Добавления Milestone")]
    [AllureOwner("Qa A")]
    public void AddMilestoneWitnEmptyNameTest()
    {
        string expectedText = "Field Name is a required field.";

        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Milestone expectedMilestone = new Milestone()
        {
            Name = "",
            Description = dashboardPage.GetLinkOfProject(), 
        };
        var milestonesPage = _milestoneSteps.AddMilestone(expectedMilestone);
        string text = milestonesPage.GetErrorAddMilestoneLabel();
        Assert.That(text, Is.EqualTo(expectedText));
    }

    [Test]
    [Order(3)]
    [AllureFeature("Negative UI Tests")]
    [AllureDescription("Проверка Добавления Milestone с количеством символов в Наименовании, " +
        "превышающих граниченое значение 250")]
    [AllureOwner("Qa A")]
    public void CheckMaxNameBoundaryTest()
    {
        string expectedText = "Successfully added the new milestone.";

        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Milestone milestoneMaxName = new Milestone()
        {
            Name = new string('A', 260),
            Description = dashboardPage.GetLinkOfProject(), 
        };
        var expectedMilestoneName = _milestoneSteps.AddMilestone(milestoneMaxName).MilestoneName.Last().Text;
        Assert.That(expectedMilestoneName, Is.EqualTo(milestoneMaxName.Name.Substring(0,250)));
    }

    [Test]
    [Order(4)]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка Диалогового окна при попытке удаления Milestone")]
    [AllureOwner("Qa A")]
    public void DialogWindowTest()
    {
        string expectedTextDialogWindow = "Confirmation";
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Assert.That(_milestoneSteps.CheckDialogWindow(), Is.EqualTo(expectedTextDialogWindow));
        //Assert.That(milestonesPage.DialWindConfirmCheckBox.Displayed, Is.True);
    }

    [Test]
    [Order(5)]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка удаления Milestone")]
    [AllureOwner("Qa A")]
    public void DeleteMilestoneTest()
    {
        string deleteExpectedText = "Successfully deleted the milestone (s).";
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Assert.That(
            _milestoneSteps
                .DeleteMilestone(),
            Is.EqualTo(deleteExpectedText));
    }
}