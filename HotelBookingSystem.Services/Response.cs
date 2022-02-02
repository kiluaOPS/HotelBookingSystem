using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Services
{
    public class Response
    {
        public Boolean Successful { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public Response(bool defaultSuccess)
        {
            Successful = defaultSuccess;
        }
        public Response() { }
    }
}
