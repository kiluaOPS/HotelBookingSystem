using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.QueryParameters
{
    public  class AvailabilityParameters
    {
        [BindRequired]
        public int HotelId { get; set; }
        [BindRequired]
        public int Capacity { get; set; }
        [BindRequired]
        public DateTime StartDate { get; set; }
        [BindRequired]
        public DateTime EndDate { get; set; }
    }
}
