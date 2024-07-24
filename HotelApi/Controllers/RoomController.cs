using HotelApplication.Services.BaseServices;
using HotelDomain.Entities;
using HotelInfrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetAllRoom()
        {
            var rooms = await _service.GetAllTable();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var rooms = await _service.GetTable(id);

            if (rooms == null)
            {
                return BadRequest("Task Not Found");
            }
            else
            {
                return Ok(rooms);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Room>> AddRoom(Room room)
        {

            var validator = new RoomValidation();
            var result = await validator.ValidateAsync(room);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var rooms = await _service.AddTable(room);
            return Ok(rooms);
        }
        [HttpPut]
        public async Task<ActionResult<Room>> UpdateRoom(Room room)
        {
            var validator = new RoomValidation();
            var result = await validator.ValidateAsync(room);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var rooms = await _service.UpdateTable(room);
            return Ok(rooms);

        }

        [HttpDelete]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var rooms = await _service.DeleteTable(id);

            if (rooms == null)
            {
                return BadRequest("Task Not Found");
            }
            else
            {
                return Ok(rooms);
            }

        }
    }
}
