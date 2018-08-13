using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<int> Multiple_Id = new List<int>();

        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        [Given(@"User calls AddHotel api")]
        public void GivenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
            Multiple_Id.Add(hotel.Id);


        }
        [Given(@"User has provided Id '(.*)' to get details of that id")]
        public void GivenUserHasProvidedIdToGetDetailsOfThatId(int id)
        {
            hotel.Id = id;
            
        }


        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }
        [When(@"User calls GetHotelById api")]
        public void WhenUserCallsGetHotelByIdApi()
        {
            hotel = HotelsApiCaller.GetHotel(hotel.Id);
            
        }
        
       


        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }
        [Then(@"Hotel should be present in the resposne as per givrn id '(.*)'")]
        public void ThenHotelShouldBePresentInTheResposneAsPerGivrnId(int id)
        {
            hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response",id));
        }
        [When(@"User calls api for checking entries of hotel")]
        [Then(@"Hotel should be present as per given Id")]
        public void ThenHotelShouldBePresentAsPerGivenId()
        {
            foreach (int item in Multiple_Id)
            {
                var x = hotels.Find(ht => ht.Id == item);
                x.Should().NotBeNull(string.Format("Hotel  not found in response"));
            }
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
