using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Pages;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Steps;
public class LoginSteps : BaseStep
{
    private LoginPage _loginPage;

    public LoginSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
    }

    // Комплексные
    [AllureStep]
    public DashboardPage SuccessfulLogin(string username, string password)
    {
        _loginPage.EmailInput.SendKeys(username);
        _loginPage.PswInput.SendKeys(password);
        _loginPage.ClickLoginInButton();

        return new DashboardPage(Driver);
    }

    [AllureStep]
    public LoginPage IncorrectLogin(string username, string password)
    {
        _loginPage.EmailInput.SendKeys(username);
        _loginPage.PswInput.SendKeys(password);
        _loginPage.ClickLoginInButton();

        return _loginPage;
    }

    [AllureStep]
    public string ErorrTextLogin()
    {
        return _loginPage.ErrorLabel.Text;
    }
}