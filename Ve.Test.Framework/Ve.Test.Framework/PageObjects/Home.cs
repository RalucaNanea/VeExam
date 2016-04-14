using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Ve.Test.Framework.Support;

namespace Ve.Test.Framework.PageObjects
{
    public class Home
    {
        [FindsBy(How = How.CssSelector, Using = "#accessibleNav .site-nav--has-dropdown a")]
        public IWebElement womenCategoryBtn;

        public void Visit()
        {
            Browser.Driver.Navigate().GoToUrl("http://clerkenwell-london.com/");

            if (Utils.isAlertPresent(2))
            {
                IAlert alert = Browser.Driver.SwitchTo().Alert();
                alert.Accept();
            }
        }

    }
}
