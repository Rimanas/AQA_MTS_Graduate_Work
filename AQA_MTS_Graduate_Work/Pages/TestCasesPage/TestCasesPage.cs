using AQA_MTS_Graduate_Work.Helpers;
using AQA_MTS_Graduate_Work.Pages.AddTestcasePage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.TestCasesPage;
    internal class TestCasesPage : TestCaseBasePage
{
    private static string END_POINT = "index.php?/suites/view/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By AddTestCaseBtnBy = By.XPath("//*[@id='sidebar-cases-add']/span");
    private static readonly By DeleteMilestoneBtnBy = By.CssSelector("[class='button button-negative button-delete']");
    private static readonly By DialogWindowLabelBy = By.CssSelector("[class='ui-dialog-title']");
    private static readonly By DialWindConfirmCheckBoxBy = By.CssSelector("[id='confirm-check']");
    private static readonly By DialWindDeleteBtnBy = By.CssSelector("[data-testid='deleteCaseDialogActionDefault']");
    private static readonly By SuccessfullDeleteMilestoneTextBy = By.CssSelector("[class='message message-success']");
    // Инициализация класса
    public TestCasesPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Test Cases");
    }

    // Атомарные методы
    // Методы поиска элементов
    //public IWebElement SuccessfullyAddMilestoneText => WaitsHelper.WaitForExists(SuccessfullyAddMilestoneTextBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement AddTestCaseBtn => WaitsHelper.WaitForExists(AddTestCaseBtnBy);
    //public IWebElement DeleteMilestoneBtnAll => WaitsHelper.WaitForExists(DeleteMilestoneBtnBy);
    //public IWebElement DialogWindowLabel => WaitsHelper.WaitForExists(DialogWindowLabelBy);
    //public IWebElement DialWindConfirmCheckBox => WaitsHelper.WaitForExists(DialWindConfirmCheckBoxBy);
    //public IWebElement SuccessfullDeleteMilestoneText => WaitsHelper.WaitForExists(SuccessfullDeleteMilestoneTextBy);

    // Методы действий с элементами
    public void ClickAddTestCaseBtn() => AddTestCaseBtn.Click();
    //public void ClickDeleteMilestoneBtnAll() => DeleteMilestoneBtnAll.Click();
    //public void ClickDialWindConfirmCheckBox() => DialWindConfirmCheckBox.Click();
    //public void ClickDialWindDeleteBtn() => DialWindDeleteBtn.Click();
    //public string GetSuccessAddMilestoneLabel() => SuccessfullyAddMilestoneText.Text.Trim();
    //public string GetSuccessfullDeleteMilestoneText() => SuccessfullDeleteMilestoneText.Text.Trim();
    //public string GetDialogWindowLabelText() => DialogWindowLabel.Text.Trim();
}
