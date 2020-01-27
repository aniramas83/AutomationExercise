Feature: Create a Patient account
	As a Patient 16 or over
	I want to create an account on Summatix
	So that I can access the Summatix platform

Background:
	Given I am at create patient account page

Scenario Outline: Create patient account for 16 years or over
	Given I start the account creation process
	When I input all account details
		| Email   | ConfirmEmail | Password   | ConfirmPassword |
		| <Email> | <Email>      | <Password> | <Password>      |
	And I input all personal details
		| FirstName   | LastName   | DateOfBirth   |
		| <FirstName> | <LastName> | <DateOfBirth> |
	And I Input all location details
		| TimeZone   | Country   | State   | Zip   |
		| <TimeZone> | <Country> | <State> | <Zip> |
	And I agree to cookies policy
	And I agree to terms and conditions
	Then I verify the account creation

	Examples:
		| Email                 | Password   | FirstName | LastName | DateOfBirth | TimeZone           | Country     | State    | Zip  |
		| aniramas718@gmail.com | Test@12345 | Anitha    | Ramasamy | 16Years     | (UTC-10:00) Hawaii | New Zealand | Auckland | 2016 |
		| aniramas736@gmail.com | Test@12345 | Anitha    | Ramasamy | Over16Years | (UTC-10:00) Hawaii | New Zealand | Auckland | 2016 |

Scenario Outline: Create patient account for under 16 and over 120 years
	Given I start the account creation process
	When I input all account details
		| Email   | ConfirmEmail | Password   | ConfirmPassword |
		| <Email> | <Email>      | <Password> | <Password>      |
	And I input all personal details
		| FirstName   | LastName   | DateOfBirth   |
		| <FirstName> | <LastName> | <DateOfBirth> |
	Then I verify "<DateOfBirth>" date of birth error message is displayed

	Examples:
		| Email                 | Password   | FirstName | LastName | DateOfBirth  |
		| aniramas214@gmail.com | Test@12345 | Anitha    | Ramasamy | Under16Years |
		| aniramas274@gmail.com | Test@12345 | Anitha    | Ramasamy | Over120Years |

Scenario: Email and Password mismatch validation
	Given I start the account creation process
	When I input all account details without proceeding to next page
		| Email                 | ConfirmEmail          | Password   | ConfirmPassword |
		| aniramas834@gmail.com | aniramas833@gmail.com | Test@12345 | Test@123456     |
	Then I verify email and password mismatch error message is displayed

Scenario Outline: Invalid email validation
	Given I start the account creation process
	When I input all account details without proceeding to next page
		| Email   | ConfirmEmail | Password | ConfirmPassword |
		| <Email> | <Email>      |          |                 |
	Then I verify invalid email error message is displayed

	Examples:
		| Email      |
		| aniramas83 |

Scenario: Insecure password validation
	Given I start the account creation process
	When I input all account details without proceeding to next page
		| Email                 | ConfirmEmail          | Password | ConfirmPassword |
		| aniramas834@gmail.com | aniramas834@gmail.com | Test     | Test            |
	Then I verify insecure password error message is displayed