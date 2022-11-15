Feature: Register

In ordr to be able to sign in with the application as it should and s

@tag1
Scenario: As a user i should be able to create an account
	Given I navigate to the website "http://automationpractice.com/index.php"
	When I click on the sign in button
	And I enter my email address as "Olis@yahoo.com"
	And I click on the create an account button
	Then your personal information page should display

	@tag2
	Scenario: I want to be able to enter my personal information
	Given I click on the title button
	And I enter my Firstname and LastName
	When I enter my password
	And I select my date of birth 

	@tag3
	Scenario: I want to be able to complete my personal information
	Given I enter my address fields and values as shown below 
	| Fields                | Values        |
	| AddressFirstName      | Everybody     |
	| AddressLastName       | Goodguy       |
	| Address               | 20 qwe close  |
	| city                  | Oslo          |
	| State                 | Alaska        |
	| Zip/Postal code       | 89564         |
	| AdditionalInformation | grew up early |
	| HomePhoneNumber       | 067665432     |
	| MobilePhoneNumber     | 08739424203   |
	| AddressAlias          | Selenium      |
	And I click on register button
	Then I should be registered