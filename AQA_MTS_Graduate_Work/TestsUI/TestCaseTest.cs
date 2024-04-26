using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using Allure.NUnit.Attributes;

namespace AQA_MTS_Graduate_Work.TestsUI;
internal class TestCaseTest : BaseTest
{

    [Test, Order(1)]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка Загрузки Файла")]
    public void FileUploadTest()
    {
        var myFile = "myFile.jpg";

        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Assert.That(TestCaseSteps.AddFile(myFile));       
    }
}