Feature: Google search
As a Goole Search user I want to be able to searh for items and get the results back.

Background: 
	Given I navigated to Google home page

Scenario Outline:  As a user I want to be able to search for different items and see the search results
	When I enter '<searchItem>' into search bar
		And I press Enter key on my keyboard
	Then search results list of '<searchItem>' is displayed

	Examples: 
	| searchItem	 |
	| Toyota Supra	 |
	| Nissan GT-R	 |
	| Subaru WRX STI |
