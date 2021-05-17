Feature: OrderT-Shirt
	

@mytag
Scenario: Place an Order for a T-Shirt
	Given I am on the Signin Page
	And I click on Signin
	And I enter email address and password
	When I click on login
	Then I click on t-shirts
	And click on tshirt image
	Then click on Add to cart
	And Proceed to checkout
	Then Proceed to Payment
	And Take a screenshot
	Then I Click on logOut