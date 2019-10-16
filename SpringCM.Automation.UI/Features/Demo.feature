Feature: Demo
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: I have the application running
Given The application running

Scenario: See SpringCM in Action
	Given The 'Contract management Software | SpringCM' is dispalyed in search results 
	When I click on 'The 'Contract management Software | SpringCM' link
	Then The Contract Management page is displayed
	When I click on the 'Watch Our Product Demo' button
	Then The Contract Management Demo page is displayed
	When I click on the 'Play' button
	Then The validation messages are displayed
	When I fill in the required fields and click 'Play' button
	Then The video player for the product demo displayed