using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace AQA_MTS_Graduate_Work.TestsUI;
public class PopUpMessageTest : BaseTest
{
    [Test]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка Всплывающего Twitter сообщения")]
    [AllureOwner("Qa A")]

    public void PopUpMessageIconTwitterTest()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.MouseHoverBird();
        Thread.Sleep(1000);
        Assert.That(dashboardPage.GetTwitterText, Is.EqualTo("Follow TestRail on Twitter for relevant TestRail updates."));
    }

    [Test]
    [AllureFeature("Positive UI Tests")]
    [AllureDescription("Проверка Всплывающего 1 сообщения")]
    [AllureOwner("Qa A")]

    public void PopUpMessageNavigateTest()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.MouseHoverNavigate();
        Assert.That(dashboardPage.GetNavigateBtnText, Is.EqualTo("Alina Alina"));
    }
}