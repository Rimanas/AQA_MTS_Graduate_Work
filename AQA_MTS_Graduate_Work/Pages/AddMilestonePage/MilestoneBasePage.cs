﻿using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages.AddMilestonePage;
    public class MilestoneBasePage : BasePage
    {
        // Инициализация класса
        public MilestoneBasePage(IWebDriver driver) : base(driver)
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