Feature: Login

Scenario: Login with valid credentials
	Given A user is logged out
	When I login with valid credentials
	Then I have logged in

Scenario: Login with invalid credentials
	Given A user is logged out
	When I login with valid credentials
	Then I have not logged in
