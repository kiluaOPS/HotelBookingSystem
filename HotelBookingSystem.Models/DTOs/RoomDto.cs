using HotelBookingSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Domain.DTOs
{
    public class RoomDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid HotelId.")]
        public int HotelId { get; set; } = -1;
        [Range(1, 3, ErrorMessage = "Please insert a valid capacity")]
        public int Capacity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid RoomType.")]
        public RoomType RoomType { get; set; }
    }
}
