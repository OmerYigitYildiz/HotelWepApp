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
using Microsoft.AspNetCore.Mvc;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllCustomerTable()
        {
            var customers = await _service.GetAllTable();
            if (customers == null)
            {
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, null, "Müşteri bulunamadı."));
            }
            var response = new ApiResponse((int)HttpStatusCode.OK, customers, "Müşteriler başarıyla getirildi.");
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetTable(Guid id)
        {
            var customer = await _service.GetTable(id);
            if (customer == null)
            {
                var response = new ApiResponse((int)HttpStatusCode.NotFound, null, "Müşteri bulunamadı.");
                return NotFound(response);
            }
            var successResponse = new ApiResponse((int)HttpStatusCode.OK, customer, "Müşteri başarıyla getirildi.");
            return Ok(successResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddCustomer(CustomerModel model)
        {
            var validator = new CustomerValidation();
            var result = await validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                var errorResponse = new ApiResponse((int)HttpStatusCode.UnprocessableEntity, result.Errors, "Doğrulama başarısız oldu.");
                return UnprocessableEntity(errorResponse);
            }

            var customerAdd = await _service.AddTable(model);
            var customer = HotelMapper.Mapper.Map<Customer>(customerAdd);
            var successResponse = new ApiResponse((int)HttpStatusCode.Created, customer, "Müşteri başarıyla eklendi.");
            return CreatedAtAction(nameof(GetTable), new { id = customer.Id }, successResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateCustomer(CustomerUpdateModel customer)
        {
            var validator = new CustomerUpdateModelValidation();
            var result = await validator.ValidateAsync(customer);

            if (!result.IsValid)
            {
                var errorResponse = new ApiResponse((int)HttpStatusCode.UnprocessableEntity, result.Errors, "Doğrulama başarısız oldu.");
                return UnprocessableEntity(errorResponse);
            }

            var customerUpdate = await _service.UpdateTable(customer);
            var updatedCustomer = HotelMapper.Mapper.Map<Customer>(customerUpdate);
            var successResponse = new ApiResponse((int)HttpStatusCode.OK, updatedCustomer, "Müşteri başarıyla güncellendi.");
            return Ok(successResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteTableId(Guid id)
        {
            var customerDelete = await _service.DeleteTable(id);
            if (customerDelete == null)
            {
                var response = new ApiResponse((int)HttpStatusCode.NotFound, null, "Müşteri bulunamadı.");
                return NotFound(response);
            }
            var successResponse = new ApiResponse((int)HttpStatusCode.OK, null, "\r\nMüşteri başarıyla silindi.");
            return Ok(successResponse);
        }
    }
}
