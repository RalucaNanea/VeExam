using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace Ve.Test.Framework.Support
{
    public class Browser
    {
        public static IWebDriver Driver { get; set; }

        public static void Initialize()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
    }
}
