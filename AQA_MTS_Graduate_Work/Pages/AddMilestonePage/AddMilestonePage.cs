﻿using AQA_MTS_Graduate_Work.Helpers;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
    public class AddMilestonePage: BasePage
{
    private static string END_POINT = "index.php?/milestones/add/4";

    //Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By InputFieldNameBy = By.Id("name");
    private static readonly By AddButtonBy = By.Id("accept");
    private static readonly By SuccessfullyAddMilestoneTextBy = By.CssSelector("[class='message message-success']");

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
    public IWebElement AddButton => WaitsHelper.WaitForExists(AddButtonBy);
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement InputFieldName => WaitsHelper.WaitForExists(InputFieldNameBy);
    public IWebElement SuccessfullyAddMilestoneText => WaitsHelper.WaitForExists(SuccessfullyAddMilestoneTextBy);


    // Методы действий с элементами
    public void ClickAddButton() => AddButton.Click();

    public string GetSuccessAddMilestoneLabel() => SuccessfullyAddMilestoneText.Text.Trim();
}