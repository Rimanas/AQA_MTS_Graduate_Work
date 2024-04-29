using AQA_MTS_Graduate_Work.Elements;
using AQA_MTS_Graduate_Work.Helpers;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
    public class AddMilestonePage: BasePage
{
    private static string END_POINT = "index.php?/milestones/add/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By InputFieldNameBy = By.Id("name");
    private static readonly By InputFieldDescriptionBy = By.Id("description_display");
    private static readonly By AddButtonBy = By.Id("accept");
    private static readonly By SuccessfullyAddMilestoneTextBy = By.CssSelector("[class='message message-success']");
    private static readonly By ProjectLinkBy = By.LinkText("3project");

    // Инициализация класса

    public AddMilestonePage(IWebDriver driver) : base(driver)
    {
    }
    public AddMilestonePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }


    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Add Milestone");
    }

    // Методы поиска элементов
    public Button AddButton => new(Driver, AddButtonBy);
    public UIElement TitleLabel => new(Driver, TitleLabelBy);
    public UIElement InputFieldName => new(Driver, InputFieldNameBy);
    public IWebElement InputFieldDescription => WaitsHelper.WaitForExists(InputFieldDescriptionBy);
    public IWebElement SuccessfullyAddMilestoneText => WaitsHelper.WaitForExists(SuccessfullyAddMilestoneTextBy);
    public IWebElement ProjectLink => WaitsHelper.WaitForExists(ProjectLinkBy);

    // Методы действий с элементами
    public void ClickAddButton() => AddButton.Click();

    public string GetSuccessAddMilestoneLabel() => SuccessfullyAddMilestoneText.Text.Trim();
    public string GetProjectIdFromLink() => ProjectLink.GetAttribute("href").Substring(57);

}