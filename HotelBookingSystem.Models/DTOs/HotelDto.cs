using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.DTOs
{
    public class HotelDto
    {

        [Required(ErrorMessage = "Hotel name is required.")]
        public string Name { get; set; }
    }
}
