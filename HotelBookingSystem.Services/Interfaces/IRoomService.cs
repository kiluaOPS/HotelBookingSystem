using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace HotelBookingSystem.Services
{
    public interface IRoomService
    {
        Task<Response<Room>> AddRoomAsync(RoomDto roomDto);
        Task<Response<Room>> GetRoomAsync(int roomId);
        Task<Response<List<Room>>> GetAllRoomsAsync();
    }
}