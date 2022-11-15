Feature: login

In order to use the application I should be logged in

@tag1
Scenario Outline: I want to be able to login with my username and password
	Given I navigate to the url http://www.adactinhotelapp.com/Register.php
	When I enter the <"username"> and <"password">
	And I click the sign in button
	Then I should be logged in to the application


	Examples:  
	| username				 | password |
	|  olis@yahoo.com        |      novemberbatch1    |