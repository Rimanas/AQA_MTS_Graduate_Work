using AQA_MTS_Graduate_Work.Helpers;
using AQA_MTS_Graduate_Work.Pages.AddTestcasePage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.TestCasesPage;
    internal class TestCasesPage : BasePage
{
    private static string END_POINT = "index.php?/suites/view/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By AddTestCaseBtnBy = By.XPath("//*[@id='sidebar-cases-add']/span");
    
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

    // Методы поиска элементов
 
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement AddTestCaseBtn => WaitsHelper.WaitForExists(AddTestCaseBtnBy);
    
    // Методы действий с элементами
    public void ClickAddTestCaseBtn() => AddTestCaseBtn.Click();

}