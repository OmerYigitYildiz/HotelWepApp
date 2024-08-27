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
using HotelApplication.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using HotelApplication.Models.Response;
using System.Net;

namespace HotelApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ReservedController : ControllerBase
    {
        private readonly IReservedService _service;

        public ReservedController(IReservedService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllReservedTable()
        {
            var reserved = await _service.GetAllTable();
            if (reserved == null)
            {
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, null, "Rezervasyon bulunamadı."));
            }
            var response = new ApiResponse((int)HttpStatusCode.OK, reserved, "Rezervasyonlar başarıyla getirildi.");
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetReservedTable(Guid id)
        {
            var reserved = await _service.GetTable(id);
            if (reserved == null)
            {
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, null, "Rezervasyon bulunamadı."));
            }
            return Ok(new ApiResponse((int)HttpStatusCode.OK, reserved, "Rezervasyon başarıyla getirildi."));
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddReserved(ReservedModel reservedModel)
        {
            var validator = new ReservedValidation();
            var result = await validator.ValidateAsync(reservedModel);

            if (!result.IsValid)
            {
                return UnprocessableEntity(new ApiResponse((int)HttpStatusCode.UnprocessableEntity, result.Errors, "Doğrulama başarısız oldu."));
            }

            ReservedResponseModel reservedadd;

            try
            {
                reservedadd = await _service.AddTable(reservedModel);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ApiResponse((int)HttpStatusCode.Conflict, null, ex.Message));
            }

            var reserved = HotelMapper.Mapper.Map<Reserved>(reservedadd);

            // Eğer rezervasyon başarılı bir şekilde eklendiyse
            if (reserved != null)
            {
                return CreatedAtAction(nameof(GetReservedTable), new { id = reserved.Id }, new ApiResponse((int)HttpStatusCode.Created, reserved, "Rezervasyon başarıyla eklendi."));
            }
            else
            {
                // Eğer rezervasyon eklenemediyse
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiResponse((int)HttpStatusCode.InternalServerError, reserved, "Seçtiğiniz tarihler arasındaki oda dolu."));
            }
        }


        [HttpPut]
        public async Task<ActionResult<ApiResponse>> ReservedUpdate(ReservedUpdateModel reserved)
        {

            var validator = new ReservedUpdateModelValidation();
            var result = await validator.ValidateAsync(reserved);

            if (!result.IsValid)
            {
                return UnprocessableEntity(new ApiResponse((int)HttpStatusCode.UnprocessableEntity, result.Errors, "Doğrulama başarısız oldu."));
            }

            var reservedupdate = await _service.UpdateTable(reserved);
            var updatedReserved = HotelMapper.Mapper.Map<Reserved>(reservedupdate);
            return Ok(new ApiResponse((int)HttpStatusCode.OK, updatedReserved, "Rezervasyon başarıyla güncellendi."));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteTableId(Guid id)
        {
            var reserveddelete = await _service.DeleteTable(id);
            if (reserveddelete == null)
            {
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, null, "Rezervasyon bulunamadı."));
            }
            return Ok(new ApiResponse((int)HttpStatusCode.OK, null, "Rezervasyon başarıyla silindi."));
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetReservedWithRoomsAsync()
        {
            var reservedsWithBooks = await _service.GetAllWithRoomsAsync();
            return Ok(new ApiResponse((int)HttpStatusCode.OK, reservedsWithBooks, "Oda rezervasyonları başarıyla getirildi."));
        }

    }
}
