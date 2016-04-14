using Shouldly;
using TechTalk.SpecFlow;
using Ve.Test.Framework.PageObjects;
using Ve.Test.Framework.Support;

namespace Ve.Tests.Steps
{
    [Binding]
    public class SalesSteps : StepBase
    {
        private string saleProductPriceDisplayedOnCategory { get; set; }

        [Given(@"I navigate to Sale category page")]
        public void WhenINavigateToSaleCategoryPage()
        {
            Site.Page<Category>().GoToSaleCategoryPage();
        }

        [When(@"I select a product with discount")]
        public void WhenISelectAProductWithDiscount()
        {
            saleProductPriceDisplayedOnCategory = Site.Page<Category>().GetSalePrice();
            Site.Page<Category>().SelectFirstDisplayedProduct();
        }

        [Then(@"the same product discount is displayed on product page")]
        public void ThenTheSameSalePriceIsDisplayedOnProductPage()
        {
            Site.Page<Product>().GetSalePrice().ShouldBe(saleProductPriceDisplayedOnCategory);
        }

        [Given(@"I navigate to a product page with sale item on it")]
        public void GivenINavigateToAProductPageWithSaleItemOnIt()
        {
            Site.Page<Product>().GoToAProductPage(Site.Page<Product>().saleProductUrl);
        }
    }
}
