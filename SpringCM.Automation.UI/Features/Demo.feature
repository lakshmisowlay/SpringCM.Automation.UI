Feature: Demo
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: I have the application running
	Given The application running
	And The 'Contract management Software | SpringCM' is dispalyed in search results
	
Scenario: Contract Management page is displayed
	When I click on The 'Contract Management Software | SpringCM' result
	Then The 'Contract Management' page is displayed

Scenario: Contract management demo page displayed
	When I click on The 'Contract Management Software | SpringCM' result
	And I click on the Watch Our Product Demo button
	Then The Contract Management Demo page is displayed

Scenario: Contract management form validation
	When I click on The 'Contract Management Software | SpringCM' result
	And I click on the Watch Our Product Demo button
	And I play the demo by clearing the fields
	Then The validation messages are displayed

Scenario: See SpringCM in Action
	When I click on The 'Contract Management Software | SpringCM' result
	And I click on the Watch Our Product Demo button
	When I fill in the required fields and play video
		| FirstName | LastName | Email                | Phone      | CompanyName | Country |
		| John      | Doe      | JohnDoe@DocuSign.com | 6667778899 | DocuSign    | USA     |
	Then The video player for the product demo displayed