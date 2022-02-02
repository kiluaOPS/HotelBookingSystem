using HotelBookingSystem.Data.Context;
using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public class HotelService : IHotelService
    {
        private BookingContext _context;

        public HotelService(BookingContext context)
        {
            _context = context;
        }
        public async Task<Response<Hotel>> AddHotelAsync(HotelDto hotelDto)
        {
            var response = new Response<Hotel>();
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Name == hotelDto.Name);
            if (hotel == null)
            {
                hotel = new Hotel
                {
                    Name = hotelDto.Name
                };
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                response.Successful = true;
                response.Payload = hotel;
            }
            else
            {
                response.Errors.Add($"Hotel with name {hotelDto.Name} already exists.");
            }

            return response;
        }

        public async Task<Response<Hotel>> GetHotelAsync(int hotelId)
        {
            var response = new Response<Hotel>(true);
            response.Payload = await _context.Hotels.FindAsync(hotelId);
            return response;
        }

        public async Task<Response<List<Hotel>>> GetAllHotelsAsync()
        {
            var response = new Response<List<Hotel>>(true);
            response.Payload = await _context.Hotels.ToListAsync();
            return response;
        }


        public async Task<Response<Hotel>> GetHotelByNameAsync(string hotelName)
        {
            var response = new Response<Hotel>(true);
            response.Payload = await _context.Hotels.FirstOrDefaultAsync(x => x.Name == hotelName);
            return response;
        }

        public async Task DeleteHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            _context.RemoveRange(hotels);
            await _context.SaveChangesAsync();
        }
    }
}
