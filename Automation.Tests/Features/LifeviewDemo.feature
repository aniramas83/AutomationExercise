Feature: LifeivewDemo
	Automation of the following scenario 
•	Search for 'Lifeview' on the Homepage  
•	Click on 'Lifeview' link  
•	In the 'LifeView' page, verify the bread crumbs on the top is 'Home Partnering with us Superannuation funds LifeView'  
     ---Could not find bread crumb with above 'Home Partnering with us Superannuation funds LifeView'. So not validating the option
•	Click on 'Request a demo' button  
•	Enter relevant data in the form
•	DO NOT SUBMIT THE FORM - Created a blank step to submit

Background:
	Given I am at MLC home page

@smoke
Scenario Outline: Lifeview demo form
	When I search for "LifeView" on the homepage
	And I select the "LifeView" resulted link
	And I request a demo
	And I input demo data as:
		| Label        | Value                |
		| Name         | Anitha               |
		| Company      | ANZ                  |
		| Email        | aniramas83@gmail.com |
		| Phone        | 02102579612          |
		| Date         | <Date>               |
		| TimeStandard | <TimeStandard>       |
		| Details      | Sample demo input    |
	Then I submit the request form

	Examples:
		| Date        | TimeStandard |
		| 20-Jan-2020 | PM           |
		| 28-Feb-2020 | AM           |
		|             | AM           |