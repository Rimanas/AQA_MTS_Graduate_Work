using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace AQA_MTS_Graduate_Work.TestsUI;
public class PopUpMessageTest : BaseTest
{
    [Test]
    [Description("Проверка Всплывающего сообщения")]
    public void PopUpMessageDownloadTest()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.MouseHover();
        Thread.Sleep(1000);
        string Text = Driver.FindElement(By.CssSelector("[class='navigation-username']")).Text;
        
        Assert.That(Text, Is.EqualTo("Download"));
    }

    [Test]
    [Description("Проверка Всплывающего Twitter сообщения")]

    public void PopUpMessageIconTwitterTest()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.MouseHoverBird();
        Thread.Sleep(18000);
        Assert.That(dashboardPage.IconTwitterText.Text, Is.EqualTo("Follow TestRail on Twitter for relevant TestRail updates."));
    }

    [Test]
    [Description("Проверка Всплывающего 1 сообщения")]

    public void PopUpMessageNavigateTest()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        dashboardPage.MouseHoverNavigate();
        Assert.That(dashboardPage.GetNavigateBtnText, Is.EqualTo("Alina Alina"));
    }
}