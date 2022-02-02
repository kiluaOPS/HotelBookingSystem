using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace HotelBookingSystem.Services
{
    public interface IBookingService
    {
        Task<Response<Booking>> AddBookingAsync(BookingDto bookingDto);
        Task<Response<Booking>> GetBookingAsync(int bookingId);
        Task<Response<List<Booking>>> GetAllBookingsAsync();
        Task<Response<List<Room>>> GetAvailableRoomsAsync(int hotelId, int capacity, DateTime startDate, DateTime endDate);
        Task<Response<Booking>> GetBookingDetailsAsync(int bookingId);
    }
}