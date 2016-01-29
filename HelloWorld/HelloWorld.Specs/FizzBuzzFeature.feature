Feature: FizzBuzzFeature
		I wanna to check output of FizzBuzz feature

@FizzBuzz
Scenario: Enter zero
	Given I have entered 0
	When I call FizzBuzzTranslator
	Then the result should be 0
