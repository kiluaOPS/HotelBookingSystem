using HotelBookingSystem.Data.Context;
using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private BookingContext _context;

        public BookingService(BookingContext context)
        {
            _context = context;
        }
        public async Task<Response<Booking>> AddBookingAsync(BookingDto bookingDto)
        {
            var response = new Response<Booking>();

            if (bookingDto.StartDate > bookingDto.EndDate)
            {
                response.Errors.Add("Booking dates are not valid.");
                return response;
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(x => x.RoomId == bookingDto.RoomId &&
                ((x.StartDate >= bookingDto.StartDate && x.StartDate <= bookingDto.EndDate) ||
                (x.EndDate >= bookingDto.StartDate && x.EndDate <= bookingDto.EndDate)));
            if (booking == null)
            {
                booking = new Booking
                {
                    RoomId = bookingDto.RoomId,
                    EndDate = bookingDto.EndDate,
                    StartDate = bookingDto.StartDate
                };
                _context.Add(booking);
                await _context.SaveChangesAsync();
                response.Successful = true;
                response.Payload = booking;
            }
            else
            {
                response.Errors.Add("Room was already booked for the specified period.");
            }

            return response;
        }


        public async Task<Response<Booking>> GetBookingAsync(int bookingId)
        {
            var response = new Response<Booking>(true);
            response.Payload = await _context.FindAsync<Booking>(bookingId);
            return response;
        }

        public async Task<Response<List<Booking>>> GetAllBookingsAsync()
        {
            var response = new Response<List<Booking>>(true);
            response.Payload = await _context.Bookings.ToListAsync();
            return response;
        }

        public async Task<Response<List<Room>>> GetAvailableRoomsAsync(int hotelId, int capacity, DateTime startDate, DateTime endDate)
        {
            var response = new Response<List<Room>>(true);
            response.Payload = await _context.Rooms.Where(
                r => r.Hotel.HotelId == hotelId &&
                r.Capacity >= capacity &&
                !r.Bookings.Any(b => (b.StartDate >= startDate && b.StartDate <= endDate) ||
                (b.EndDate >= startDate && b.EndDate <= endDate))).ToListAsync(); ;
            return response;
        }

        public async Task<Response<Booking>> GetBookingDetailsAsync(int bookingId)
        {
            var response = new Response<Booking>(true);
            response.Payload = await _context.Bookings
                .Include(x => x.Room)
                .Include(x => x.Room.Hotel)
                .Where(x => x.BookingId == bookingId)
                .Select(x => new Booking
                {
                    BookingId = x.BookingId,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    RoomId = x.RoomId,
                    Room = new Room
                    {
                        HotelId = x.Room.HotelId,
                        RoomId = x.Room.RoomId,
                        RoomType = x.Room.RoomType,
                        Capacity = x.Room.Capacity,
                        Hotel = new Hotel
                        {
                            HotelId = x.Room.HotelId,
                            Name = x.Room.Hotel.Name
                        }
                    }
                }).FirstOrDefaultAsync();
            return response;
        }

        public async Task DeleteBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            _context.RemoveRange(bookings);
            await _context.SaveChangesAsync();
        }
    }
}
