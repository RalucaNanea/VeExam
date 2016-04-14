using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ve.Test.Framework.Support;

namespace Ve.Test.Framework.PageObjects
{
    public class Product
    {
        [FindsBy(How = How.CssSelector, Using = "#addToCart")]
        public IWebElement AddToCartBtn;

        [FindsBy(How = How.CssSelector, Using = ".product-info-grid h1")]
        public IWebElement productName;

        [FindsBy(How = How.CssSelector, Using = "#productPrice")]
        public IWebElement productPrice;

        [FindsBy(How = How.CssSelector, Using = "#quantity")]
        public IWebElement productQuantity;

        public string productUrl = "http://clerkenwell-london.com/collections/skirts/products/azores-skirt";

        public string saleProductUrl = "http://clerkenwell-london.com/collections/unexpected-finds/products/alice-culottes";

        [FindsBy(How = How.CssSelector, Using = ".product-pricing .sale")]
        public IWebElement salePrice;

        public void ScrollToElement(IWebElement webElement)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)Browser.Driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public void ScrollToQuantityTextBox()
        {
            ScrollToElement(productQuantity);
        }

        public string GetProductQuantity()
        {
            return productQuantity.GetAttribute("value");
        }

        public string GetProductPrice()
        {
            return productPrice.Text;
        }

        public void GoToAProductPage(string Url)
        {
            Browser.Driver.Navigate().GoToUrl(Url);

            // When navigating from cart to product page by changing the domain, then VePrompt is popping up
            //The alert should be accepted and the VePrompt iframe should be closed

            if (Utils.isAlertPresent(2))
            {
                IAlert alert = Browser.Driver.SwitchTo().Alert();
                alert.Accept();
            }
        }

        public List<ProductDetails> AddProductDetails(List<ProductDetails> list)
        {
            list.Add(new ProductDetails
            {
                Name = Site.Page<Product>().productName.Text,
                Price = Site.Page<Product>().productPrice.Text,
                Quantity = Site.Page<Product>().GetProductQuantity(),
                Url = Browser.Driver.Url,

            });
            return list;
        }

        public string GetSalePrice()
        {
            var test = Regex.Replace(salePrice.Text, "[^0-9.,]", "");
            return Regex.Replace(salePrice.Text, "[^0-9.,]", "");
        }

    }
}
