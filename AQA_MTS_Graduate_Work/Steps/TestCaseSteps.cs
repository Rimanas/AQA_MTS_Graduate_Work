using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Models;
using AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
using AQA_MTS_Graduate_Work.Pages.AddtestCasePage;
using OpenQA.Selenium;
using System.Reflection;

namespace AQA_MTS_Graduate_Work.Steps;
    public class TestCaseSteps(IWebDriver driver) : BaseStep(driver)
    {
    [AllureStep]
    public bool AddFile(string file)
    {
        // Получаем путь к исполняемому файлу (exe)
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        // Конструируем путь к файлу внутри проекта
        string filePath = Path.Combine(assemblyPath, "Resources", file);
        Thread.Sleep(1000);
        AddTestCasePage = new AddTestCasePage(Driver, true);
        Thread.Sleep(1000);
        AddTestCasePage.ClickAddImageButton();
        AddTestCasePage.AttachFileBtn.SendKeys(filePath);
        return AddTestCasePage.AttachFile.Displayed;
    }
}