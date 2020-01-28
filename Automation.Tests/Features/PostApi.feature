Feature: PostApi
	//https://digitalapi.auspost.com.au/postage/v4/catalogue/service.json?category=INTERNATIONAL&from=AU&to=NZ


Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
