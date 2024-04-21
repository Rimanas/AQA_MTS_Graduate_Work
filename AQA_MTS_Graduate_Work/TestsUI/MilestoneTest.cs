﻿using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using Allure.NUnit.Attributes;

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
        AddMilestonePage addMilestonePage = new AddMilestonePage(Driver);
        OwnProjectPage ownProjectPage = new OwnProjectPage(Driver);
        MilestonesPage milestonesPage = new MilestonesPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickOpenProjectBtn();
        ownProjectPage.ClickAddMilestoneButton();
        addMilestonePage.InputFieldName.SendKeys("AutoMilestone");
        addMilestonePage.ClickAddButton();
        //Assert.That(addMilestonePage.IsPageOpened);
        Assert.That(milestonesPage.GetSuccessAddMilestoneLabel, Is.EqualTo(expectedText));
    }

    [Test]
    [Order(2)]
    [Description("Проверка Диалогового окна при попытке удаления Milestone")]
    [AllureSubSuite("Successful Dialog Window Test")]
    public void DialogWindowTest()
    {
        string expectedTextDialogWindow = "Confirmation";
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
        Assert.That(milestonesPage.GetDialogWindowLabelText, Is.EqualTo(expectedTextDialogWindow));
        Assert.That(milestonesPage.DialWindConfirmCheckBox.Displayed, Is.True);
    }

    [Test]
    [Order(3)]
    [Description("Проверка удаления Milestone")]
    [AllureSubSuite("Successful Deelete Milestone Test")]
    public void DeleteMilestoneTest()
    {
        string deleteExpectedText = "Successfully deleted the milestone (s).";
        OwnProjectPage ownProjectPage = new OwnProjectPage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickOpenProjectBtn();
        Thread.Sleep(2000);
        ownProjectPage.ClickMilestonesButton();
        Assert.That(
            new MilestoneSteps(Driver)
                .DeleteMilestone(),
            Is.EqualTo(deleteExpectedText));
    }
}
