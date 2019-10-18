Feature: ResourceLibrary
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
		
Background: Application is Running
	Given I have the application running

Scenario: SpringCM Resource Library displayed on the menu
	When I select the 'Resources' from the navigation
	Then The 'Resources Library' menu is displayed

Scenario: SpringCM Resource Library page is displayed
	When I select the 'Resources' from the navigation
	And I select the 'Resources Library' sub menu from the 'Resources' menu
	Then The defualt page content is displayed on the 'Resources' page
	
Scenario: SpringCM Resource Library Media Types dropdow is displayed
	When I select the 'Resources' from the navigation
	And I select the 'Resources Library' sub menu from the 'Resources' menu
	Then The 'Media Types' dropdown list is displayed
	
Scenario: SpringCM Resource Library report contents are displayed
	When I select the 'Resources' from the navigation
	And I select the 'Resources Library' sub menu from the 'Resources' menu
	And I select 'Reports' from the 'Media Types' dropdown list
	Then The 'report' content is displayed on the Resources page