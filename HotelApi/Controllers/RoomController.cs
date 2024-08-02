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
using HotelApplication.Mapper;

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
        public async Task<ActionResult<Room>> AddRoom(RoomModel model)
        {

            var validator = new RoomValidation();
            var result = await validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var roomadd = await _service.AddTable(model);
            return HotelMapper.Mapper.Map<Room>(roomadd);
        }
        [HttpPut]
        public async Task<ActionResult<Room>> UpdateRoom(RoomUpdateModel room)
        {
            var validator = new RoomUpdateModelValidation();
            var result = await validator.ValidateAsync(room);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var roomupdate = await _service.UpdateTable(room);
            return HotelMapper.Mapper.Map<Room>(roomupdate);

        }

        [HttpDelete("{id}")]
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
