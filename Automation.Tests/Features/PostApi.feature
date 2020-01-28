Feature: PostApi
	//https://digitalapi.auspost.com.au/postage/v4/catalogue/service.json?category=INTERNATIONAL&from=AU&to=NZ

Scenario Outline: Validate postal cost to different countries
	When I call australia post api with:
		| FromCountry   | ToCountry   |
		| <FromCountry> | <ToCountry> |
	Then I validate the price of the post

	Examples:
		| FromCountry | ToCountry |
		| AU          | NZ        |
		| AU          | CN        |
		| AU          | BE        |