using HotelBookingSystem.Domain.DTOs;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelService _hotelService;

        public HotelController(ILogger<HotelController> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        [HttpGet("{name}")]
        public async Task<ObjectResult> Get(string name)
        {
            var response = await _hotelService.GetHotelByNameAsync(name);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            var response = await _hotelService.GetHotelAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var response = await _hotelService.GetAllHotelsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] HotelDto hotel)
        {
            //Should add mappers to transform entity in Dto
            var response = await _hotelService.AddHotelAsync(hotel);
            
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