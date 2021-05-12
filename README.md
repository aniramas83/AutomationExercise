# AutomationExercise
Web automation exercises

## Coding details:
Test is written in .net 4.7.2 using libraries of Selenium, Specflow and so on.
Four projects created in this solution to separate business logic with code logic. But core projects can be nuget packaged for easier mnaintenance than local projects.

All the business scenarios are written in BDD format.

Test execution can be either done from visual studio test explorer or nunit console run.
Example nunit command:
.\nunit3-console.exe Automation.Tests.dll --where="cat == smoke"

## Scenario information.
Three scenarios are included as part of this test sln.

### Scenario1: Borrowing limit calculation

Input required for this scenario are Applicant type, dependants, loan purpose, income, other income, expenses, current home loan repayment, 
other loan repayment, other commitmments and credit card limit. 

**Improvement - Scenario can be improved by utilising the default values.  
Getting input only if it differs than default. **



### Scenario2: Default value restore

No input required
After calculation, clicking on start over set the fields default value.


Inputs for above scenarios can be updated via feature file of specflow.

## Other scenarios
**Recommendation is to leave end to end happy path scenario at UI automation and rest move to API automation**
**Examples**
1. UI automation coverage - Few combinations of borrowing limit calculation
2. API vautomation coverage (In depth validations of below)
	a. Field validations of whether accepting correct input and rejecting invalid inputs
	b. Input combinations (leaving some default and other fields with updated values)
	c. Amount with negative values
	d. Amount with different values (int, decimal)
