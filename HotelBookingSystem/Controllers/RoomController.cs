using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            return Ok(await _roomService.GetRoomAsync(id));
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            // Should add pagination
            // Should add mappers to transform entity in Dto
            return Ok(await _roomService.GetAllRoomsAsync());
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] RoomDto room)
        {
            var response = await _roomService.AddRoomAsync(room);

            if (response.Successful)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}