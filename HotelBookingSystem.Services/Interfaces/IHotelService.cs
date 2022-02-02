using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace HotelBookingSystem.Services
{
    public interface IHotelService
    {
        Task<Response<Hotel>> AddHotelAsync(HotelDto hotelDto);
        Task<Response<Hotel>> GetHotelAsync(int hotelId);
        Task<Response<Hotel>> GetHotelByNameAsync(string hotelName);
        Task<Response<List<Hotel>>> GetAllHotelsAsync();
    }
}