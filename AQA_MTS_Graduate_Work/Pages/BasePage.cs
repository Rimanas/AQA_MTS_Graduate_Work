using AQA_MTS_Graduate_Work.Helpers.Configuration;
using AQA_MTS_Graduate_Work.Helpers;
using OpenQA.Selenium;

namespace AQA_MTS_Graduate_Work.Pages;
public abstract class BasePage
{
    protected IWebDriver Driver { get; private set; }         // свойство - драйвер
    protected WaitsHelper WaitsHelper { get; private set; }      // свойство - ожидание
    /*
    public BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }
    */

    public BasePage(IWebDriver driver, bool openPageByUrl)  // флаг -bool openPageByUrl
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        if (openPageByUrl)
        {
            OpenPageByURL();
        }
    }
    public BasePage(IWebDriver driver) : this(driver, false)
    {
    }

    protected abstract string GetEndpoint();  //  каждая страница долдна выполнить это
    public abstract bool IsPageOpened();    // можно пончть открылась страница или нет

    protected void OpenPageByURL()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
    }
}