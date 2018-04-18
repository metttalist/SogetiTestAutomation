Feature: ApiTestFeature
	In order to test the REST API framework
	As a authorized user
	I want to call and verify the REST Response

@mytag
Scenario: Test the REST API framework
	Given I am an authorized user
	When I submit the Get request to the test URL
	Then the response has the expected HTTP Code
