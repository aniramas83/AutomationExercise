Feature: PostApi
For the API test, please use the Australia Post API to calculate shipping costs for parcels of
different weights to at least three countries. In your test add what you believe should be verified/checked as part of the API.
	https://digitalapi.auspost.com.au/postage/v4/catalogue/service.json?category=INTERNATIONAL&from=AU&to=NZ

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