using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Enums;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;
        private readonly IHotelService _hotelService;
        private readonly IBookingService _bookingService;

        public TestController(ILogger<RoomController> logger, IRoomService roomService, IHotelService hotelService, IBookingService bookingService)
        {
            _logger = logger;
            _roomService = roomService;
            _hotelService = hotelService;
            _bookingService = bookingService;
        }

        [HttpPost("CreateHotel")]
        public async Task CreateHotel(int numberOfHotels)
        {
            for (int i= 0; i < numberOfHotels; i++) {
                var response = await _hotelService.AddHotelAsync(new HotelDto
                {
                    Name = $"Hotel{i}"
                });
            }
        }

        [HttpPost("CreateRooms")]
        public async Task CreateRooms()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            foreach (var hotel in hotels.Payload)
            {
                for (int i = 0; i < 6; i++)
                {
                    Random rand = new Random();
                    var roomTypeInt = rand.Next(0, 2);
                    await _roomService.AddRoomAsync(new RoomDto
                    {
                        HotelId = hotel.HotelId,
                        RoomType = (RoomType)roomTypeInt,
                        Capacity = roomTypeInt
                    });
                }
            }
        }

        [HttpPost("CreateBookings")]
        public async Task CreateBookings()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            foreach (var room in rooms.Payload)
            {
                Random random = new Random();
                int startDateShift = random.Next(0, 15);
                int endDateShift = random.Next(15, 30);
                await _bookingService.AddBookingAsync(new BookingDto
                {
                    RoomId = room.RoomId,
                    Capacity = room.Capacity,
                    EndDate = DateTime.Now.AddDays(startDateShift),
                    StartDate = DateTime.Now.AddDays(endDateShift),
                });
            }
        }
    }
}