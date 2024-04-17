using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_MTS_Graduate_Work.Pages;
public class DashboardPage : BasePage
{
    private static string END_POINT = "index.php?/dashboard";

    // Описание элементов
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By DownloadButtonBy = By.CssSelector("#clickDownload"); 
    private static readonly By IconTwitterBy = By.CssSelector("[class='icon-header-twitter']");
    private static readonly By IconTwitterTextBy = By.CssSelector("[tooltip-text*='Twitter']");
    private static readonly By DownloadTextLabelBy = By.CssSelector("[tooltip-text='Download']");

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

    public IWebElement DownloadTextLabel => WaitsHelper.WaitForExists(DownloadTextLabelBy);

    //Комплексные
    public void MouseHover()
    {
        Actions actions = new Actions(Driver);
        actions
            .MoveToElement(DownloadButton)
            .Build()
            .Perform();
    }

    public void MouseHoverBird()
    {
        Actions actions = new Actions(Driver);
        actions
            .MoveToElement(IconTwitter)
            .Build()
            .Perform();
    }
    public string DownLoadText()
    {
        return DownloadTextLabel.Text;
    }
    public string GetDownloadTextLabel() => DownloadTextLabel.Text.Trim();
}
