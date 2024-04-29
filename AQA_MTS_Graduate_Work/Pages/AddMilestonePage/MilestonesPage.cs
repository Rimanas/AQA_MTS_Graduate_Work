using AQA_MTS_Graduate_Work.Helpers;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
public class MilestonesPage: BasePage
{
    private static string END_POINT = "index.php?/milestones/overview/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By AddMilestoneButtonBy = By.Id("navigation-overview-addmilestones");
    private static readonly By SuccessfullyAddMilestoneTextBy = By.CssSelector("[class='message message-success']");
    private static readonly By CheckBoxSelectAllBy = By.CssSelector("#active [name='select_all']");
    private static readonly By DeleteMilestoneBtnBy = By.CssSelector("[class='button button-negative button-delete']");
    private static readonly By DialogWindowLabelBy = By.CssSelector("[class='ui-dialog-title']");
    private static readonly By DialWindConfirmCheckBoxBy = By.Id("confirm-check");
    private static readonly By DialWindDeleteBtnBy = By.CssSelector("[data-testid='deleteCaseDialogActionDefault']");
    private static readonly By SuccessfullDeleteMilestoneTextBy = By.CssSelector("[class='message message-success']");
    // Инициализация класса

    public MilestonesPage(IWebDriver driver) : base(driver)
    {
    }

    public MilestonesPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {

    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Milestones");
    }

    // Атомарные методы
    public IWebElement SuccessfullyAddMilestoneText => WaitsHelper.WaitForExists(SuccessfullyAddMilestoneTextBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement CheckBoxSelectAll => WaitsHelper.WaitForExists(CheckBoxSelectAllBy);
    public IWebElement DeleteMilestoneBtnAll => WaitsHelper.WaitForExists(DeleteMilestoneBtnBy);
    public IWebElement DialogWindowLabel => WaitsHelper.WaitForExists(DialogWindowLabelBy);
    public IWebElement DialWindConfirmCheckBox => WaitsHelper.WaitForExists(DialWindConfirmCheckBoxBy);
    public IWebElement DialWindDeleteBtn => WaitsHelper.WaitForExists(DialWindDeleteBtnBy);
    public IWebElement SuccessfullDeleteMilestoneText => WaitsHelper.WaitForExists(SuccessfullDeleteMilestoneTextBy);

    // Методы действий с элементами
    public void ClickCheckBoxSelectAll() => CheckBoxSelectAll.Click();
    public void ClickDeleteMilestoneBtnAll() => DeleteMilestoneBtnAll.Click();
    public void ClickDialWindConfirmCheckBox() => DialWindConfirmCheckBox.Click();
    public void ClickDialWindDeleteBtn() => DialWindDeleteBtn.Click();
    public string GetSuccessAddMilestoneLabel() => SuccessfullyAddMilestoneText.Text.Trim();
    public string GetSuccessfullDeleteMilestoneText() => SuccessfullDeleteMilestoneText.Text.Trim();
    public string GetDialogWindowLabelText() => DialogWindowLabel.Text.Trim();
}