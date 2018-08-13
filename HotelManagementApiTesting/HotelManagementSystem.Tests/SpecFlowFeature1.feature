Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario Outline: User adds hotel in database by providing valid inputs and find that hotel with it's Id  
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	And User has provided Id '<id>' to get details of that id
	When User calls GetHotelById api
	Then Hotel should be present in the resposne as per givrn id '<id>'
Examples: 
| id | name   |
| 4  | hotel4 |

Scenario: User adds Multiple hotel in database by providing valid inputs and verifies it
	Given User provided valid Id '5'  and 'Hotel5'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	And User provided valid Id '6'  and 'hotel6'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls api for checking entries of hotel
	Then Hotel should be present as per given Id


