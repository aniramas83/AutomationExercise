Feature: TaxCalculator
On the ATO page https://www.ato.gov.au/Calculators-and-tools/Host/?anchor=STC&anchor=STC#STC/questions 
•	Navigate to the page
•	Create a test to verify calculated tax for at least three combinations of assessment year, Income and residency status 

@smoke
Scenario Outline: Tax calculator validation
	Given I am at the tax calculator page
	When I enter all required options as:
		| Label          | Value            |
		| Year           | <Year>           |
		| Amount         | <Amount>         |
		| Residency      | <Residency>      |
		| NumberOfMonths | <NumberOfMonths> |
	Then I verify the tax calculation is not null

	Examples:
		| Year    | Amount | Residency                  | NumberOfMonths |
		| 2018-19 | 500000 | Resident for full year     |                |
		| 2017-18 | 75000  | Non-resident for full year |                |
		| 2016-17 | 80000  | Part-year resident         | 2              |