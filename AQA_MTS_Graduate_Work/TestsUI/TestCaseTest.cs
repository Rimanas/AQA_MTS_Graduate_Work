using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages.AddProjectPage;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using AQA_MTS_Graduate_Work.Pages.TestCasesPage;
using AQA_MTS_Graduate_Work.Pages.AddtestCasePage;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Allure.NUnit.Attributes;

namespace AQA_MTS_Graduate_Work.TestsUI;
internal class TestCaseTest : BaseTest
{

    [Test, Order(1)]
    [Description("Проверка Загрузки Файла")]
    [AllureSubSuite("Successful Upload File Test")]
    public void FileUploadTest()
    {
        var myFile = "myFile.jpg";
        OwnProjectPage ownProjectPage = new OwnProjectPage(Driver);
        TestCasesPage testCasesPage = new TestCasesPage(Driver);
        AddTestCasePage addTestCasePage = new AddTestCasePage(Driver);
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.ClickOpenProjectBtn();
        ownProjectPage.ClickTestCaseButton();
        testCasesPage.ClickAddTestCaseBtn();
        addTestCasePage.ClickAddImageButton();
        // Получаем путь к исполняемому файлу (exe)
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);       
        // Конструируем путь к файлу внутри проекта
        string filePath = Path.Combine(assemblyPath, "Resources", myFile);
        addTestCasePage.AttachFileBtn.SendKeys(filePath);
        Assert.That(addTestCasePage.AttachFile.Displayed);    //элемент находит        
    }
}

