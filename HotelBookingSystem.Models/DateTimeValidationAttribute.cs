using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Domain
{
    public class DateTimeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (DateTime) value > DateTime.MinValue.AddDays(1);
        }

    }
}
