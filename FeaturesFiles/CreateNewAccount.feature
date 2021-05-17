Feature: CreateNewAccount
	

@Regression
Scenario: CreateNewAccount
	Given i am on the webpage
	And I click on sign in button
	Then I enter email address under create an account field
	And I click on Create an Account button
	Then I update Personal information
	And I update Address information
	Then I click on Register Button