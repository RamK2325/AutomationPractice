Feature: LoginPage


@mytag
Scenario: Login to Automation Practice Account
	Given I am on the automation practice page
	And I click on Sign in button
	Then I enter Email address
	And I enter my Password 
	Then I click on Sign in Button