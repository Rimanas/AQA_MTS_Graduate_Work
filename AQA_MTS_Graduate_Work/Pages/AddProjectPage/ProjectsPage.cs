using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_MTS_Graduate_Work.Pages.AddProjectPage;
    public class ProjectsPage : ProjectBasePage
{
    private static string END_POINT = "index.php?/admin/projects/overview";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By SuccessfullyAddProjectTextBy = By.CssSelector("[class='icon-header-twitter']");

    // Инициализация класса
    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Projects");
    }

    // Атомарные методы
    // Методы поиска элементов
    public IWebElement SuccessfullyAddProjectText => WaitsHelper.WaitForExists(SuccessfullyAddProjectTextBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);

    // Методы действий с элементами
    public string GetSuccessAddProjectLabel() => SuccessfullyAddProjectText.Text.Trim();
}