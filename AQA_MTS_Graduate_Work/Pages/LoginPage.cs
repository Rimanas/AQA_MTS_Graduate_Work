using AQA_MTS_Graduate_Work.Helpers;

namespace AQA_MTS_Graduate_Work.Pages;
public class LoginPage : BasePage
{
    private static string END_POINT = "";

    // Описание элементов
    private static readonly By EmailInputBy = By.Id("name");
    private static readonly By PswInputBy = By.Id("password");
    private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
    private static readonly By LoginInButtonBy = By.Id("button_primary");
    private static readonly By ErrorLabelBy = By.CssSelector("[data-testid='loginErrorText']");

    // Инициализация класса
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public override bool IsPageOpened()
    {
        return LoginInButton.Displayed && EmailInput.Displayed;
    }

    // Методы
    // Методы поиска элементов
    public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
    public IWebElement ErrorLabel => WaitsHelper.WaitForExists(ErrorLabelBy);
    public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
    public IWebElement RememberMeCheckbox => WaitsHelper.WaitForExists(RememberMeCheckboxBy);
    public IWebElement LoginInButton => WaitsHelper.WaitForExists(LoginInButtonBy);

    // Методы действий с элементами
    public void ClickLoginInButton() => LoginInButton.Click();

    // Методы получения свойств
    public string GetErrorLabelText() => ErrorLabel.Text.Trim();
}
