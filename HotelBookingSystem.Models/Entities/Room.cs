using HotelBookingSystem.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Domain.Entities
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
