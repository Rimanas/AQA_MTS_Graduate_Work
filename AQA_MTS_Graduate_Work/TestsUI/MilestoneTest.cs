using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Models;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.TestsUI;
public class MilestoneTest : BaseTest
{
    
    [Test]
    [Order(1)]
    [Description("Проверка Добавления Milestone")]
    [AllureSubSuite("Successful Add Milestone Test")]
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
        };
        var milestonesPage = _milestoneSteps.AddMilestone(expectedMilestone);
        string text = milestonesPage.GetSuccessAddMilestoneLabel();
        Assert.That(text, Is.EqualTo(expectedText));
    }

    [Test]
    [Order(2)]
    [Description("Проверка Диалогового окна при попытке удаления Milestone")]
    [AllureSubSuite("Successful Dialog Window Test")]
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
    [Order(3)]
    [Description("Проверка удаления Milestone")]
    [AllureSubSuite("Successful Deelete Milestone Test")]
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