using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Domain.DTOs
{
    public class BookingDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid RoomId.")]
        public int RoomId { get; set; } = -1;

        [DateTimeValidationAttribute(ErrorMessage ="Please insert a valid start date.")]
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        [DateTimeValidationAttribute(ErrorMessage = "Please insert a valid end date.")]
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        [Range(1, 3, ErrorMessage = "Please insert a valid capacity")]
        public int Capacity { get; set; } = -1;
    }
}
