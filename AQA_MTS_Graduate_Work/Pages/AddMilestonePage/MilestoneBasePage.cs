using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
    public class MilestoneBasePage : BasePage
{
    public MilestoneBasePage(IWebDriver driver) : base(driver)
    {
    }

    // Инициализация класса

    public MilestoneBasePage(IWebDriver driver, bool openPageByUrl) : base(driver)
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