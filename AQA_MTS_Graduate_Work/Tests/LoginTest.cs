using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;

namespace AQA_MTS_Graduate_Work.Tests;
public class LoginTest : BaseTest
{
    [Test]
    [Description("Проверка успешного входа")]
    public void SuccessfulLoginTest()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        DashboardPage dashboardPage = loginSteps
            .SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        Assert.That(dashboardPage.IsPageOpened);
    }
    /*
    [Test]
    [Description("Проверка входа залоченного пользователя/ Пользователь locked_out_user")]
    public void LockedUsernameLoginTest()
    {
        // Проверка

        Assert.That(
            new LoginSteps(Driver)
                .IncorrectLogin("locked_out_user", Configurator.AppSettings.Password)
                .GetErrorLabelText(),
            Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    */
        //Другой способ
        /*        LoginPage loginPage = new LoginPage(Driver);
              LoginSteps loginSteps = new LoginSteps(Driver);
              loginSteps.IncorrectLogin("locked_out_user", Configurator.AppSettings.Password);
              //loginPage.ErrorLabel.Text.Trim();
              //Is.EqualTo("Epic sadface: Password is required");
              Assert.That(loginPage.ErrorLabel.Text, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        */
    
}