using AQA_MTS_Graduate_Work.Helpers;
using AQA_MTS_Graduate_Work.Pages.AddTestcasePage;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddtestCasePage;
    internal class AddTestCasePage : TestCaseBasePage
{
    private static string END_POINT = "index.php?/cases/add/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By AddImagePreCondBtnBy = By.XPath("//*[@for=\"custom_preconds\"]/span/a/*[@class=\"icon-markdown-image\"]");
    private static readonly By DialogWindAttachFileBy = By.CssSelector("[class='ui-dialog-title']");
    private static readonly By AttachFileBtnBy = By.CssSelector("[id='libraryAddAttachment']");
    private static readonly By AttachFileBy = By.CssSelector("[title='myFile.jpg']");

    // Инициализация класса
    public AddTestCasePage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Add Test Case");
    }

    // Атомарные методы
    // Методы поиска элементов
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement AddImagePreCondBtn => WaitsHelper.WaitForExists(AddImagePreCondBtnBy);
    public IWebElement DialogWindAttachFile => WaitsHelper.WaitForExists(DialogWindAttachFileBy);
    public IWebElement AttachFileBtn => WaitsHelper.WaitForExists(AttachFileBtnBy);
    public IWebElement AttachFile => WaitsHelper.WaitForExists(AttachFileBy);

    // Методы действий с элементами
    public void ClickAddImageButton() => AddImagePreCondBtn.Click();
    public void ClickAddAttachFileButton() => AttachFileBtn.Click();

}