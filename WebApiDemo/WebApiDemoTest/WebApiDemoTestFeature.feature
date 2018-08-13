Feature: WebApiDemoTestFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>' and '<name>' for hotel
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with id '<id>' should be present in the response
Examples:
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |       
