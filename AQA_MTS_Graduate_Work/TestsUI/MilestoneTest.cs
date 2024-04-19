using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;

namespace AQA_MTS_Graduate_Work.TestsUI;

public class MilestoneTest : BaseTest
{
    
    [Test, Order(1)]
    [Description("Проверка Добавления Milestone")]
    public void AddMilestoneTest()
    {
        string expectedText = "Successfully added the new milestone.";
        AddTestCasePage addMilestonePage = new AddMilestonePage(Driver);
        OwnProjectPage ownProjectPage = new OwnProjectPage(Driver);
        MilestonesPage milestonesPage = new MilestonesPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickOpenProjectBtn();
        Thread.Sleep(2000);
        ownProjectPage.ClickAddMilestoneButton();
        addMilestonePage.InputFieldName.SendKeys("AutoMilestone");
        addMilestonePage.ClickAddButton();
        Thread.Sleep(1000);
        //Assert.That(addMilestonePage.IsPageOpened);
        Assert.That(milestonesPage.GetSuccessAddMilestoneLabel, Is.EqualTo(expectedText));
    }

    [Test, Order(2)]
    [Description("Проверка Диалогового окна при попытке удаления Milestone")]
    public void DialogWindowTest()
    {
        string expectedTextDialogWindow = "Confirmation";
        //AddMilestonePage addMilestonePage = new AddMilestonePage(Driver);
        OwnProjectPage ownProjectPage = new OwnProjectPage(Driver);
        MilestonesPage milestonesPage = new MilestonesPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickOpenProjectBtn();
        Thread.Sleep(1000);
        ownProjectPage.ClickMilestonesButton();
        milestonesPage.ClickCheckBoxSelectAll();
        milestonesPage.ClickDeleteMilestoneBtnAll();
        Thread.Sleep(1000);
        Assert.That(milestonesPage.GetDialogWindowLabelText, Is.EqualTo(expectedTextDialogWindow));
        Assert.That(milestonesPage.DialWindConfirmCheckBox.Displayed, Is.True);
    }

    [Test, Order(3)]
    [Description("Проверка удаления Milestone")]
    public void DeleteMilestoneTest()
    {
        string deleteExpectedText = "Successfully deleted the milestone (s).";
        OwnProjectPage ownProjectPage = new OwnProjectPage(Driver);
        MilestonesPage milestonesPage = new MilestonesPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickOpenProjectBtn();
        Thread.Sleep(1000);
        ownProjectPage.ClickMilestonesButton();
        milestonesPage.ClickCheckBoxSelectAll();
        milestonesPage.ClickDeleteMilestoneBtnAll();
        milestonesPage.ClickDialWindConfirmCheckBox();
        milestonesPage.ClickDialWindDeleteBtn();
        Thread.Sleep(1000);
        Assert.That(milestonesPage.GetSuccessfullDeleteMilestoneText, Is.EqualTo(deleteExpectedText));
    }
}
