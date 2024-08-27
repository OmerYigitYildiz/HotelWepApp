using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Models.Response
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, object data = null, string message = null)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
    }
}
