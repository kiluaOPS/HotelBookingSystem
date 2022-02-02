using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Services
{
    public class Response<T> : Response
    {
        public Response() { }
        public Response(bool defaultSuccess) : base(defaultSuccess) { }
        public T? Payload { get; set; }
    }
}
