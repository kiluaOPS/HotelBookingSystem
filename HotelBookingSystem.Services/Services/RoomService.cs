using HotelBookingSystem.Data.Context;
using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public class RoomService : IRoomService
    {
        private BookingContext _context;

        public RoomService(BookingContext context)
        {
            _context = context;
        }
        public async Task<Response<Room>> AddRoomAsync(RoomDto roomDto)
        {
            var response = new Response<Room>();
            if (_context.Rooms.Count(x => x.HotelId == roomDto.HotelId) < 6)
            {
                var room = new Room
                {
                    Capacity = roomDto.Capacity,
                    HotelId = roomDto.HotelId
                };
                _context.Add(room);
                await _context.SaveChangesAsync();
                response.Payload = room;
                response.Successful = true;
            }
            else
            {
                response.Errors.Add("Unable to create any more rooms for this hotel.");
            }
            return response;
        }

        public async Task<Response<Room>> GetRoomAsync(int roomId)
        {
            var response = new Response<Room>(true);
            response.Payload = await _context.FindAsync<Room>(roomId);
            return response;
        }

        public async Task<Response<List<Room>>> GetAllRoomsAsync()
        {
            var response = new Response<List<Room>>(true);
            response.Payload = await _context.Rooms.ToListAsync();
            return response;
        }

        public async Task DeleteRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            _context.RemoveRange(rooms);
            await _context.SaveChangesAsync();
        }
    }
}
