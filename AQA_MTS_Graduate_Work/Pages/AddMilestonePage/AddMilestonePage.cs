using AQA_MTS_Graduate_Work.Helpers;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
    internal class AddMilestonePage : MilestoneBasePage
{
    private static string END_POINT = "index.php?/milestones/add/4/1";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By InputFieldNameBy = By.Id("name");
    private static readonly By AddButtonBy = By.CssSelector("#accept");

    // Инициализация класса
    public AddMilestonePage(IWebDriver driver) : base(driver)
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

    // Атомарные методы
    // Методы поиска элементов
    public IWebElement AddButton => WaitsHelper.WaitForExists(AddButtonBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement InputFieldName => WaitsHelper.WaitForExists(InputFieldNameBy);

    // Методы действий с элементами
    public void ClickAddButton() => AddButton.Click();
}