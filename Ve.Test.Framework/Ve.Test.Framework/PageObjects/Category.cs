using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ve.Test.Framework.Support;

namespace Ve.Test.Framework.PageObjects
{
    public class Category
    {

        [FindsBy(How = How.CssSelector, Using = ".slideshow-content a")]
        public IWebElement _shopCollectionBtn;

        [FindsBy(How = How.CssSelector, Using = ".grid-uniform .grid-item .title-text a")]
        public IList<IWebElement> _productNameSelector;

        public string _saleCategoryUrl = "http://clerkenwell-london.com/collections/unexpected-finds";

        [FindsBy(How = How.CssSelector, Using = ".price-container")]
        public IList<IWebElement> salePrice;

        [FindsBy(How = How.CssSelector, Using = ".title-text")]
        public IList<IWebElement> _firstProduct;


        public void GoToSaleCategoryPage()
        {
            Browser.Driver.Navigate().GoToUrl(_saleCategoryUrl);
        }

        public string GetSalePrice()
        {
            var fullPrice = salePrice.First().FindElements(By.CssSelector(".sale-value")).First().Text;
            var discountPrice = salePrice.First().Text.Replace(fullPrice, "");
            return Regex.Replace(discountPrice, "[^0-9.,]", "");
        }

        public void SelectFirstDisplayedProduct()
        {
            _firstProduct.First().Click();
        }
    }
}
