Feature: AdminAddNewUser
	In order to create new user
	As a Admin
	I want to add new user to DB

@mytag
Scenario: Add two numbers
	Given I have crated a new user
	And I assign him to User Role
	When I pressed Create
	Then User should have User Role
