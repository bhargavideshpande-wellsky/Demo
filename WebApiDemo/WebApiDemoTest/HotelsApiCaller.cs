using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemoTest
{
    public class HotelsApiCaller
    {
        private static RestClient client = new RestClient("http://localhost:52018/Api");
        public static List<Hotel> AddHotels(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }
    }
}
