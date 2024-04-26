using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Models;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
    public class MilestoneSteps(IWebDriver driver) : BaseStep(driver)
{

    /*
    public MilestoneSteps(IWebDriver driver) : base(driver)
    {
        _milestonesPage = new MilestonesPage(Driver);
        _addMilestonePage = new AddMilestonePage(Driver);   
        _ownProjectPage = new OwnProjectPage(Driver);   
    }
    */

    [AllureStep]
    public MilestonesPage AddMilestone(Milestone _milestone)
    {
        Thread.Sleep(1000);
        AddMilestonePage = new AddMilestonePage(Driver, true);
        Thread.Sleep(1000);
        AddMilestonePage.InputFieldName.SendKeys(_milestone.Name);
        AddMilestonePage.ClickAddButton();
        return new MilestonesPage(Driver);   
    }
    [AllureStep]
    public string CheckDialogWindow()
    {
        MilestonesPage = new MilestonesPage(Driver, true);
        Thread.Sleep(1000);
        MilestonesPage.ClickCheckBoxSelectAll();
        MilestonesPage.ClickDeleteMilestoneBtnAll();
        return MilestonesPage.GetDialogWindowLabelText();
    }
    [AllureStep]
    public string DeleteMilestone()
    {
        MilestonesPage = new MilestonesPage(Driver, true);
        Thread.Sleep(1000);
        MilestonesPage.ClickCheckBoxSelectAll();
        MilestonesPage.ClickDeleteMilestoneBtnAll();
        MilestonesPage.ClickDialWindConfirmCheckBox();
        MilestonesPage.ClickDialWindDeleteBtn();

        return MilestonesPage.GetSuccessfullDeleteMilestoneText();
    }  
}