using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
    public class MilestoneSteps : BaseStep
{
    private MilestonesPage _milestonesPage;

    public MilestoneSteps(IWebDriver driver) : base(driver)
    {
        _milestonesPage = new MilestonesPage(Driver);
    }
    [AllureStep]
    public string DeleteMilestone()
    {
        _milestonesPage.ClickCheckBoxSelectAll();
        _milestonesPage.ClickDeleteMilestoneBtnAll();
        _milestonesPage.ClickDialWindConfirmCheckBox();
        _milestonesPage.ClickDialWindDeleteBtn();

        return _milestonesPage.GetSuccessfullDeleteMilestoneText();
    }  
}