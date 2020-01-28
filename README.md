# AutomationExercise
Web and API automation exercises

Coding details:
NUnit framework is written in .net 4.7.1 using libraries of Specflow, Selenium and so on.
Four projects created in this solution to separate business logic with code logic.

All the business scenarios are written in BDD format.

Test execution can be either done from visual studio test explorer or nunit console run.
Example nunit command:
.\nunit3-console.exe Automation.Tests.dll --where="cat == smoke"

Scenario information.
Three scenarios are included as part of this test sln.

Scenario1: Request a demo form
Input required for this scenario are
Name, Company, Phone, Details, Email. 
Optional input is Prefered date, if Prefered date is not given leaving the default date of today.

Scenario2: Tax calculation based on year, amount, 
residency status of the selected year. 
If user is partly resident of the selected year, 
need to input number of months outside country.

Validation is only ensuring tax amount greater than zero.

Scenario3: Calling Australia post api to get the international fair for parcel.
Input required for this scenario are 'country from where need to ship' and 'country where to ship the parcel'.

Validation is done only to ensure GET response is not null due to time restriction.

Inputs for above scenarios can be updated via feature file of specflow.
