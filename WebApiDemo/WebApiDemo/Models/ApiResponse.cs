using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class ApiResponse
    {
      public List<Hotel> Hotels { get; set; }
      public Status Status { get; set; }

    }
}