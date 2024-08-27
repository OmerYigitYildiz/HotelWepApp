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
using HotelApplication.Models.Response;
using System.Net;

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
        public async Task<ActionResult<ApiResponse>> GetAllRoom()
        {
            var rooms = await _service.GetAllTable();
            if (rooms == null)
            {
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, null, "Oda bulunamadı."));
            }
            var response = new ApiResponse((int)HttpStatusCode.OK, rooms, "Odalar başarıyla getirildi.");
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetRoomById(Guid id)
        {
            var room = await _service.GetTable(id);
            if (room == null)
            {
                var response = new ApiResponse((int)HttpStatusCode.NotFound, null, "Oda bulunamadı.");
                return NotFound(response);
            }
            var successResponse = new ApiResponse((int)HttpStatusCode.OK, room, "Oda başarıyla getirildi.");
            return Ok(successResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddRoom(RoomModel model)
        {
            var validator = new RoomValidation();
            var result = await validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                var errorResponse = new ApiResponse((int)HttpStatusCode.UnprocessableEntity, result.Errors, "Doğrulama başarısız oldu.");
                return UnprocessableEntity(errorResponse);
            }

            var roomAdd = await _service.AddTable(model);
            var room = HotelMapper.Mapper.Map<Room>(roomAdd);
            var successResponse = new ApiResponse((int)HttpStatusCode.Created, room, "Oda başarıyla eklendi.");
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, successResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateRoom(RoomUpdateModel room)
        {
            var validator = new RoomUpdateModelValidation();
            var result = await validator.ValidateAsync(room);

            if (!result.IsValid)
            {
                var errorResponse = new ApiResponse((int)HttpStatusCode.UnprocessableEntity, result.Errors, "Doğrulama başarısız oldu.");
                return UnprocessableEntity(errorResponse);
            }

            var roomUpdate = await _service.UpdateTable(room);
            var updatedRoom = HotelMapper.Mapper.Map<Room>(roomUpdate);
            var successResponse = new ApiResponse((int)HttpStatusCode.OK, updatedRoom, "Oda başarıyla güncellendi.");
            return Ok(successResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteRoom(Guid id)
        {
            var roomDelete = await _service.DeleteTable(id);
            if (roomDelete == null)
            {
                var response = new ApiResponse((int)HttpStatusCode.NotFound, null, "Oda bulunamadı.");
                return NotFound(response);
            }
            var successResponse = new ApiResponse((int)HttpStatusCode.OK, null, "Oda başarıyla silindi.");
            return Ok(successResponse);
        }
    }
}
