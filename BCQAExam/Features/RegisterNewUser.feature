Feature: Register
	In order to use the system
	As a registered user of the system
	I want to be able to register a user

Scenario: Register New User
	Given I am in the page allowing Registration
	When I enter random username only
#	| UserName                | Password |
#	| lorenad@bizcover.com.au | test1234 |
	Then I should be redirected to Registration Page
	When I fill registration form and press Register
	| Name   | Lastname | Password | Address             | City      | State  | ZIP   | Mobile     |
	| Lorena | De Canas | test1234 | 8101 Sabrina Street | Anchorage | Alaska | 99501 | 1234567899 |
	Then I should be redirected to my account page
	When I press Sign out link
	Then I should be redirected back to login page
	When I login with random username generated earlier 
	| Password |
	| test1234 |
	Then I again should be redirected to my account page

