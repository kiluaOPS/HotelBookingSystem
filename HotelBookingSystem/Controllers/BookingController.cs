using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.QueryParameters;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            //Should add mappers to transform entity in Dto
            return Ok(await _bookingService.GetBookingAsync(id));
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            //Should add mappers to transform entity in Dto
            return Ok(await _bookingService.GetAllBookingsAsync());
        }

        [HttpPost]
        public async Task<ObjectResult> Post(BookingDto booking)
        {

            var response = await _bookingService.AddBookingAsync(booking);
            if (response.Successful)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("AvailableRooms")]
        public async Task<ObjectResult> GetAvailableRooms([FromQuery] AvailabilityParameters parameters)
        {
            return Ok(await _bookingService.GetAvailableRoomsAsync(parameters.HotelId, parameters.Capacity, parameters.StartDate, parameters.EndDate));
        }

        [HttpGet("Details/{id}")]
        public async Task<ObjectResult> GetBookingDetails(int bookingId)
        {
            return Ok(await _bookingService.GetBookingDetailsAsync(bookingId));
        }
    }
}