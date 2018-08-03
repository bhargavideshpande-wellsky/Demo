using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class Status
    {
        public ApiStatus Apistatus { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }

    }
    public enum ApiStatus
    {
        Success,
        Failure,
        Warning
    }
}