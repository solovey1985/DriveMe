Feature: DriverSearchBehavour
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have created new  Route
	And I have added 3 pick boarding Locations into the Route
	When I press add
	Then the Route should contain 3 boarding locations
