using OpenQA.Selenium.Support.UI;
using System;
using Ve.Test.Framework.Support;

namespace Ve.Test.Framework
{
    public class Utils
    {

        public static Boolean isAlertPresent(int seconds)
        {
            Boolean foundAlert = false;
            WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(seconds));

            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                foundAlert = true;
            }
            catch
            {
                foundAlert = false;
            }
            return foundAlert;
        }
    }
}
