Feature: LoanCalculator
	As a borrower
	I want to fill in my income and financial details
	So I can understand how much I could borrow

@smoke
Scenario Outline: Validate borrowing limit
	Given I am at loan calculator page
	When I enter your details as:
		| Label           | Value        |
		| ApplicationType | <Type>       |
		| Dependants      | <Dependants> |
		| PropertyPurpose | <Purpose>    |
	And I enter your earnings as:
		| Label           | Value         |
		| IncomeBeforeTax | <Income>      |
		| OtherIncome     | <OtherIncome> |
	And I enter your expenses as:
		| Label            | Value             |
		| LivingExpenses   | <Expense>         |
		| CurrentHlRepay   | <HlRepay>         |
		| OtherLoanRepay   | <OtherLoan>       |
		| OtherCommitments | <Commitments>     |
		| CreditCardLimit  | <CreditCardLimit> |
	Then I verify borrowing estimate is "<Limit>"

	Examples:
		| Type   | Dependants | Purpose      | Income  | OtherIncome | Expense | HlRepay | OtherLoan | Commitments | CreditCardLimit | Limit    |
		| Single | 0          | HomeToLiveIn | 80,000  | 10,000      | 500     | 0       | 140       | 0           | 10,000          | $500,000 |
		| Joint  | 2          | Investment   | 160,000 | 10,000      | 2000    | 0       | 140       | 0           | 10,000          | $743,000 |

@smoke
Scenario: Validate fields default value
	Given I am at loan calculator page
	And I entered required details for borrowing calculation
	When I click on start over to start over the application
	Then I verify all the field values are set to default