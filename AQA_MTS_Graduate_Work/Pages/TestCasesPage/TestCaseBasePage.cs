using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddTestcasePage;
    public class TestCaseBasePage : BasePage
    {
        // Инициализация класса
        public TestCaseBasePage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsPageOpened()
        {
            throw new NotImplementedException();
        }

        protected override string GetEndpoint()
        {
            throw new NotImplementedException();
        }
    }