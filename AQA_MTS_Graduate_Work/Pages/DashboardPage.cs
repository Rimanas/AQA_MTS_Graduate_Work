using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;

namespace AQA_MTS_Graduate_Work.Pages;
public class DashboardPage : BasePage
{
    private static string END_POINT = "index.php?/dashboard";

    // Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By DownloadButtonBy = By.Id("clickDownload");
    private static readonly By IconTwitterBy = By.CssSelector("[class='icon-header-twitter']");
    private static readonly By IconTwitterTextBy = By.XPath("//*[@href=\"http://twitter.com/testrail\" and @tabindex=\"-1\"]");
    private static readonly By NavigateBtnBy = By.CssSelector("[data-testid='navigationUser']");
    private static readonly By NavigateBtnTextBy = By.CssSelector("[data-testid='navigationUser']");
    private static readonly By AddProjectBtnBy = By.CssSelector("[class='sidebar-button']");
    //private static readonly By OpenProjectBtnBy = By.XPath("//*[@id='project-4']/div/div/*[@href='index.php?/projects/overview/4']");
    private static readonly By OpenProjectButtonBy = By.LinkText("3project");

    //WaitsHelper.WaitForVisibilityLocatedBy(By.LinkText("3project")).Click();
    // Инициализация класса
    public DashboardPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("All Projects");
    }

    // Атомарные Методы
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement DownloadButton => WaitsHelper.WaitForExists(DownloadButtonBy);
    public IWebElement IconTwitter => WaitsHelper.WaitForExists(IconTwitterBy);
    public IWebElement IconTwitterText => WaitsHelper.WaitForExists(IconTwitterTextBy);
    public IWebElement NavigateBtn => WaitsHelper.WaitForExists(NavigateBtnBy);
    public IWebElement NavigateBtnText => WaitsHelper.WaitForExists(NavigateBtnTextBy);
    public IWebElement AddProjectBtn => WaitsHelper.WaitForExists(AddProjectBtnBy);
    public IWebElement OpenProjectButton => WaitsHelper.WaitForExists(OpenProjectButtonBy);

    //Комплексные

    public void MouseHoverBird()
    {
        Actions actions = new Actions(Driver);
        actions
            .MoveToElement(IconTwitter)
            .Build()
            .Perform();
    }

    public void MouseHoverNavigate()
    {
        Actions actions = new Actions(Driver);
        actions
            .MoveToElement(NavigateBtn)
            .Build()
            .Perform();
    }

    public void ClickAddProjectBtn() => AddProjectBtn.Click();
    public void ClickOpenProjectBtn() => OpenProjectButton.Click();
    public string TwitterText()
    {
        return IconTwitterText.GetAttribute("tooltip-text");
    }
    public string NavigateBtnTextMethod()
    {
        return NavigateBtnText.Text;
    }
    public string GetNavigateBtnText() => NavigateBtnText.Text.Trim();
    public string GetTwitterText() => IconTwitterText.GetAttribute("tooltip-text");
    public string GetLinkOfProject() => OpenProjectButton.GetAttribute("href").Substring(57);

    public string GetProjectId(string projectId)
    {
        Regex re = new Regex("https://aqa9001.testrail.io/index.php?/projects/overview/", RegexOptions.IgnoreCase);
        projectId = re.Replace(projectId, ""); // удаляем c часть https://
        return projectId;
    }
}
