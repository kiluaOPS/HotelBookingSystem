using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Domain.Entities
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
