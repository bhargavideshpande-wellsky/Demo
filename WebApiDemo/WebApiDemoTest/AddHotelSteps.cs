using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using WebApiDemo.Models;

namespace WebApiDemoTest
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        List<Hotel> hotelsResponse = new List<Hotel>();
        [Given(@"User provided valid Id '(.*)' and '(.*)' for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
           hotel.Id = id;
            hotel.Name = name;
        }
        
        [Given(@"User has added required details for hotel")]
        public void GivenUserHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotelsResponse = HotelsApiCaller.AddHotels(hotel);
        }

        [Then(@"Hotel with id '(.*)' should be present in the response")]
        public void ThenHotelWithIdShouldBePresentInTheResponse(int id)
        {
            hotel = hotelsResponse.Find(ht => ht.Id == id);
            hotel.Should().NotBeNull(string.Format("Hotle with id {0} not found in response", id));
        }


        private void SetHotelBasicDetails()
        {
            hotel.roomsAvailable = 5;
            hotel.localityCode = 40024;
            hotel.Address = "Nagpur";

        }
    }
}
