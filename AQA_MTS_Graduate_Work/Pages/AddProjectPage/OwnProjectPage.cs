using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddProjectPage;
    public class OwnProjectPage : ProjectBasePage
{
    private static string END_POINT = "index.php?/projects/overview/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.Id("navigation-project");
    private static readonly By AddMilestoneButtonBy = By.CssSelector("[id='navigation-overview-addmilestones']");
    private static readonly By MilestonesButtonBy = By.CssSelector("[id='navigation-milestones']");
    private static readonly By TestCaseButtonBy = By.CssSelector("[id= 'navigation-suites']");
    // Инициализация класса
    public OwnProjectPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("3project");
    }
    //Комплексные
    public void ClickAddMilestoneButton() => AddMilestoneButton.Click();
    public void ClickMilestonesButton() => MilestonesButton.Click();
    public void ClickTestCaseButton() => TestCaseButton.Click();
    // Атомарные методы
    // Методы поиска элементов
    public IWebElement AddMilestoneButton => WaitsHelper.WaitForExists(AddMilestoneButtonBy);
    public IWebElement MilestonesButton => WaitsHelper.WaitForExists(MilestonesButtonBy);
    public IWebElement TestCaseButton => WaitsHelper.WaitForExists(TestCaseButtonBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);

}