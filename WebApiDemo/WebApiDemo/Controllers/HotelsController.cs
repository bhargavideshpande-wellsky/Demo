using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;



namespace WebApiDemo.Controllers
{
    public class HotelsController : ApiController
    {
        private static int counter = 3;
        private static List<Hotel> hotels = new List<Hotel>()
        {
            new Hotel(){ Name = "Radisson", roomsAvailable= 12,Address= "Nagpur", localityCode=024, Id = 1 },
            new Hotel(){ Name = "Novotel", roomsAvailable = 50,Address = "Pune",localityCode=026,Id = 2 },
            new Hotel(){ Name = "Tuli Imperial",roomsAvailable = 18,Address = "Mumbai",localityCode=025,Id = 3 }
        };
        public ApiResponse GetAllHotels()
        {
            try
            {
                return new ApiResponse()
                {
                    Hotels = hotels,
                    Status = new Status()
                    {
                        Apistatus = ApiStatus.Success,
                        errorMessage = string.Empty,
                        errorCode = 200
                    }
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Hotels = null,
                    Status = new Status()
                    {
                        Apistatus = ApiStatus.Failure,
                        errorCode = 500,
                        errorMessage = "Internal Server Error"
                    }
                };
            }
            
        }
        public ApiResponse GetHotelById(int id)
        {
            Hotel specificHotel = hotels.Find(x => x.Id == id);
            if (specificHotel != null)
            {
                return new ApiResponse()
                {
                    Hotels = new List<Hotel>() { specificHotel },
                    Status = new Status()
                    {

                        Apistatus = ApiStatus.Success,
                        errorCode = 200
                    }
                };
            }
            return new ApiResponse()
            {
                Hotels = null,
                Status = new Status()
                {
                    Apistatus = ApiStatus.Failure,
                    errorCode = 500,
                    errorMessage = "Internal Server Error"
                }
            };
        }
        public ApiResponse PostNewHotel(Hotel hotelToBeCreated)
        {
            
            if (hotelToBeCreated != null)
            {
               hotelToBeCreated.Id = ++counter;
                
                hotels.Add(hotelToBeCreated);
                return new ApiResponse()
                {
                    Hotels = hotels,
                    Status = new Status()
                    {
                        Apistatus = ApiStatus.Success,
                        errorMessage = "Hotel added Successfully!",
                        errorCode = 200
                    }
                };
            }
            return new ApiResponse()
            {
                Hotels = null,
                Status = new Status()
                {
                    Apistatus = ApiStatus.Failure,
                    errorCode = 500,
                    errorMessage = "Internal Server Error"
                }
            };
        }
        public ApiResponse PutBooking(int id, [FromBody] int noOfRooms)
        {
            Hotel hotelId = hotels.Find(y => y.Id == id);
            if(hotelId != null)
            {
                if(hotelId.roomsAvailable == 0)
                {
                    return new ApiResponse()
                    {
                        Status = new Status()
                        {
                            Apistatus = ApiStatus.Failure,
                            errorCode = 500,
                            errorMessage = "Rooms are not Available"
                        }
                    };
                }
                else
                {
                    var rooms = hotelId.roomsAvailable - noOfRooms;
                    if (rooms > 0)
                    {
                        hotelId.roomsAvailable = rooms;
                        return new ApiResponse()
                        {
                            Hotels = new List<Hotel>() { hotelId },
                            Status = new Status()
                            {
                                Apistatus = ApiStatus.Success,
                                errorMessage = "Rooms are booked Successfully!",
                                errorCode = 200
                            }
                        };
                    }
                    else
                    {
                        return new ApiResponse()
                        {
                            Status = new Status()
                            {
                                Apistatus = ApiStatus.Failure,
                                errorCode = 500,
                                errorMessage = "Rooms are not Available"
                            }
                        };
                    }
                }
            }
            return new ApiResponse()
            {
                Status = new Status()
                {
                    Apistatus = ApiStatus.Failure,
                    errorCode = 500,
                    errorMessage = "Internal Server Error"
                }
            };
        }
        public ApiResponse DeleteHotelEntry(int id)
        {
            Hotel hotelToBeDelete = hotels.Find(z => z.Id == id);
            if (hotelToBeDelete != null)
            {
                hotels.Remove(hotelToBeDelete);
                hotelToBeDelete.Id = counter--;
                return new ApiResponse()
                {
                    Hotels = hotels,
                    Status = new Status()
                    {
                        Apistatus = ApiStatus.Success,
                        errorMessage = "Rooms are booked Successfully!",
                        errorCode = 200
                    }
                };
            }
            return new ApiResponse()
            {
                Hotels = null,
                Status = new Status()
                {
                    Apistatus = ApiStatus.Failure,
                    errorCode = 500,
                    errorMessage = "Internal Server Error"
                }
            };
        }
    }
}
