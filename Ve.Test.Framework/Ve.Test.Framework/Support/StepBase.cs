using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace Ve.Test.Framework.Support
{
    public class StepBase
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (Browser.Driver == null || ((RemoteWebDriver)Browser.Driver).SessionId == null)
            {
                Browser.Initialize();
                Browser.Driver.Manage().Cookies.DeleteAllCookies();
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (Browser.Driver != null)
                Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }

        [TestFixtureTearDown]
        public void AfterFeature()
        {
            Browser.Driver.Quit();
        }
    }
}
