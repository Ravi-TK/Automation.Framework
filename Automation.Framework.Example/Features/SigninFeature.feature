Feature: SigninFeature
	In order to see my home page
	As a a registered user 
	I want to be able to login in to my BBC account

Scenario: Navigating to BBC login Page
	Given I am on BBC Landing page 
	When I click on sign in button
	Then I am navigated to BBC sign in page 
