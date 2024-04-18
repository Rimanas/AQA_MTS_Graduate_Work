using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_MTS_Graduate_Work.Pages.AddProjectPage;
public class AddProjectPage : ProjectBasePage
{
    private static string END_POINT = "index.php?/admin/projects/add/1";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By InputFieldNameBy = By.Id("name");
    private static readonly By AddButtonBy = By.CssSelector("#accept");

    // Инициализация класса
    public AddProjectPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Add Project");
    }

    // Атомарные методы
    // Методы поиска элементов
    public IWebElement AddButton => WaitsHelper.WaitForExists(AddButtonBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement InputFieldName => WaitsHelper.WaitForExists(InputFieldNameBy);

    // Методы действий с элементами
    public void ClickAddButton() => AddButton.Click();


}