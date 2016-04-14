Feature: SaleItems
	In order to show customers the sale product prices
	As a site owner
	I want to display the discount product prices on all corresponding pages


Scenario: Discount displayed on product page is applied on basket page as well
Given I navigate to a product page with sale item on it
When I add the current product to the basket
Then the basket reflects the correct quantity and price of the item/s added to it

Scenario: Product discount displayed on category page is applied to product page as well
Given I navigate to Sale category page
When I select a product with discount
Then the same product discount is displayed on product page 