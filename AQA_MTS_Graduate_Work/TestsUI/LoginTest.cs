﻿using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Pages;
using AQA_MTS_Graduate_Work.Steps;

namespace AQA_MTS_Graduate_Work.TestsUI;
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
    [Test]
    [Description("Проверка Неуспешного входа, ввод некорректных данных")]
    public void InvalidUsernameLoginTest()
    {
        // Проверка в Builder стилистике
        Assert.That(
            new LoginSteps(Driver)
                .IncorrectLogin("ssdd", Configurator.AppSettings.Password)
                .GetErrorLabelText(),
            Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }
}