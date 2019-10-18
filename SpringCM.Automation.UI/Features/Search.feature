Feature: Search
	In order to view details of Contract Management
	As a user
	I want to be able to search for contract management
	
Background: Application is Running
Given The application running

#place holder text is 'Search' not 'Type to search'
Scenario: Search field is dispalyed
	When I click on search button
	Then Search field with 'Search' is displayed 

Scenario: Search text is displayed
	When I click on search button
	And I enter 'Contract Management' on the search field
	Then 'Contract Management' is displayed on the search field

Scenario: Search result is available
	When I click on search button
	And I enter 'Contract Management' on the search field
	And I scroll to the bottom of the search results
	Then The 'Contract Management Software | SpringCM' link is visible

