﻿Feature: ResourceLibrary
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: I have the application running
Given The application running

Scenario: SpringCM Resource Library
	Given I have the application running
	When I select the 'Resources' menu
	Then The 'Resources' menu is displayed
	When I select the 'Resources Library' sub menu from the 'Resources' menu
	Then The defualt page content is displayed on the 'Resources' page
	When I select the 'Media Types' sub menu from the 'Resources' menu
	Then The 'Media Types' dropdown list is displayed
	When I select 'Reports' from the 'Media Types' dropdown list
	Then The report content is displayed on the 'Resources' page

