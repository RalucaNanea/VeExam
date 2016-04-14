Feature: Quantity and price of the shopping cart items 
	In order to show customers the shopping cart
	As a site owner
	I want to display the updated quantity and price of the items added to the basket

Background: 
	Given I navigate to Clerkenwell website
	And I navigate further to a product page
	When I add the current product to the basket

Scenario: Increase quantity of products 
	When I increase the quantity of the existing product
	Then the basket is updated with the correct quantity and price

Scenario: Add one product to the basket 
	Then the basket reflects the correct quantity and price of the item/s added to it

Scenario: Remove the product from basket 
	When I remove an existing product from shopping cart
	Then the basket page is empty 

Scenario: Add many products to the basket 
	When I add a different product to the basket
	Then the basket reflects the correct quantity and price of the item/s added to it

Scenario: Add same product to the basket 
When I add same product to the basket 
Then the basket contains one product with Quantity equals with 2




