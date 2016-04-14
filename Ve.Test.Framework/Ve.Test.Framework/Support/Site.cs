using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Ve.Test.Framework.Support
{
    public class Site
    {
        //Creates the page object factory and instantiate the page objects

        public static T Page<T>()
        {
            var page = Activator.CreateInstance<T>();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }
    }
}
