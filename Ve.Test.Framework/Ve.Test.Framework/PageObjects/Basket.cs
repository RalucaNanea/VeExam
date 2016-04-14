using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ve.Test.Framework.Support;

namespace Ve.Test.Framework.PageObjects
{
    public class Basket
    {
        [FindsBy(How = How.CssSelector, Using = ".cart-quantity")]
        public IWebElement unitQuantity;

        [FindsBy(How = How.CssSelector, Using = ".medium-down--one-third a")]
        public IWebElement removeButton;

        [FindsBy(How = How.CssSelector, Using = ".wrapper h2")]
        public IWebElement emptyCartMessage;

        [FindsBy(How = How.CssSelector, Using = ".grid span a")]
        public IList<IWebElement> _allBasketProductNames;

        [FindsBy(How = How.CssSelector, Using = ".medium-down--text-left span")]
        public IList<IWebElement> _allBasketProductPrices;

        [FindsBy(How = How.CssSelector, Using = ".grid .cart-quantity")]
        public IList<IWebElement> _allBasketProductQuantities;

        [FindsBy(How = How.CssSelector, Using = ".update-cart")]
        public IWebElement UpdateCartBtn;

        [FindsBy(How = How.CssSelector, Using = ".cart-subtotal--price")]
        public IWebElement totalBasketValue;

        public void GoToBasket()
        {
            Browser.Driver.Navigate().GoToUrl("http://clerkenwell-london.com/cart");
        }

        public string GetUnitQuantityValue()
        {
            return unitQuantity.GetAttribute("value");
        }

        public void RemoveProductFromBasket()
        {
            removeButton.Click();
        }

        public int TotalNumberOfProductsShownOnBasket()
        {
            return _allBasketProductNames.Count;
        }

        public List<ProductDetails> GetBasketProducts()
        {
            var numberOfProducts = _allBasketProductNames.Count;
            var products = new List<ProductDetails>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                products.Add(new ProductDetails
                {
                    Name = _allBasketProductNames[i].Text,
                    Price = _allBasketProductPrices[i].Text,
                    Quantity = _allBasketProductQuantities[i].GetAttribute("value"),
                });
            }
            return products;
        }

        public void compareProductDetails(List<ProductDetails> productList, List<ProductDetails> basketList)
        {
            for (int i = 0, j = productList.Count - 1; i < basketList.Count && j >= 0; i++, j--)
            {
                Assert.AreEqual(productList[j].Name, basketList[i].Name);
                Assert.AreEqual(productList[j].Price, basketList[i].Price);
                Assert.AreEqual(productList[j].Quantity, basketList[i].Quantity);
            }

        }

        public void IncreaseProductQuantity()
        {
            _allBasketProductQuantities.First().Clear();
            _allBasketProductQuantities.First().SendKeys("2");
        }


        public double GetDoubledPriceWithoutCurrency(string unitPrice)
        {
            return Convert.ToDouble(Regex.Replace(unitPrice, "[^0-9.,]", "")) * 2;
        }

        public double GetTotalBasketWithoutCurrency(string totalBasketValue)
        {
            return Convert.ToDouble(Regex.Replace(totalBasketValue, "[^0-9.,]", ""));
        }
    }


    public class ProductDetails
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Url { get; set; }
    }
}
