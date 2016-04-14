using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using Ve.Test.Framework.PageObjects;
using Ve.Test.Framework.Support;

namespace Ve.Tests.Steps
{
    [Binding]
    public class BasketSteps : StepBase
    {
        private List<ProductDetails> _basketProducts { get; set; }
        private List<ProductDetails> _productDetailsList { get; set; }

        [Given(@"I navigate to Clerkenwell website")]
        public void GivenINavigateToClerkenwellWebsite()
        {
            Site.Page<Home>().Visit();
        }

        [Given(@"I navigate further to a product page")]
        public void GivenINavigateFurtherToAProductPage()
        {
            Site.Page<Home>().womenCategoryBtn.Click();
            Site.Page<Category>()._shopCollectionBtn.Click();
            Site.Page<Category>()._productNameSelector.First().Click();
        }

        [When(@"I add the current product to the basket")]
        public void WhenIAddTheCurrentProductToTheBasket()
        {
            _productDetailsList = Site.Page<Product>().AddProductDetails(new List<ProductDetails>());
            Site.Page<Product>().AddToCartBtn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Site.Page<Basket>().GoToBasket();
        }

        [Then(@"the basket reflects the correct quantity and price of the item/s added to it")]
        public void ThenTheBasketReflectsTheCorrectQuantityAndPriceOfTheItemSAddedToIt()
        {
            _basketProducts = Site.Page<Basket>().GetBasketProducts();
            Site.Page<Basket>().compareProductDetails(_productDetailsList, _basketProducts);
        }

        [When(@"I increase the quantity of the existing product")]
        public void WhenIIncreaseTheQuantityOfTheExistingProduct()
        {
            Site.Page<Basket>().IncreaseProductQuantity();
            Site.Page<Basket>().UpdateCartBtn.Click();
        }

        [Then(@"the basket is updated with the correct quantity and price")]
        public void ThenTheBasketIsUpdatedWithTheCorrectQuantityAndPrice()
        {
            var doubledPriceWithoutCurrency = Site.Page<Basket>().GetDoubledPriceWithoutCurrency(_productDetailsList[0].Price);
            Site.Page<Basket>().GetTotalBasketWithoutCurrency(Site.Page<Basket>().totalBasketValue.Text).ShouldBe(doubledPriceWithoutCurrency);
        }

        [When(@"I remove an existing product from shopping cart")]
        public void WhenIRemoveAnExistingProductFromShoppingCart()
        {
            Site.Page<Basket>().RemoveProductFromBasket();
        }

        [Then(@"the basket page is empty")]
        public void ThenTheBasketPageIsEmpty()
        {
            Site.Page<Basket>().emptyCartMessage.Text.ShouldBe("IT APPEARS THAT YOUR CART IS CURRENTLY EMPTY.");
        }

        [When(@"I add a different product to the basket")]
        public void WhenIAddADifferentProductToTheBasket()
        {
            Site.Page<Product>().GoToAProductPage(Site.Page<Product>().productUrl);

            _productDetailsList = Site.Page<Product>().AddProductDetails(_productDetailsList);
            Site.Page<Product>().AddToCartBtn.Click();
            Site.Page<Basket>().GoToBasket();
        }

        [When(@"I add same product to the basket")]
        public void WhenIAddSameProductToTheBasket()
        {
            Site.Page<Product>().GoToAProductPage(_productDetailsList[0].Url);

            _productDetailsList = Site.Page<Product>().AddProductDetails(_productDetailsList);
            Site.Page<Product>().AddToCartBtn.Click();
            Site.Page<Basket>().GoToBasket();
        }

        [Then(@"the basket contains one product with Quantity equals with (.*)")]
        public void ThenTheBasketContainsOneProductWithQuantityEqualsWith(int p0)
        {
            Site.Page<Basket>()._allBasketProductNames.Count.ShouldBe(1);
            Site.Page<Basket>()._allBasketProductQuantities.Count.ShouldBe(p0);
        }
    }
}
