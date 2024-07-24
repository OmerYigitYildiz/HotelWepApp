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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomerTable()
        {
            var customer = await _service.GetAllTable();
            return Ok(customer);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetTable(int id)
        {
            var customer = await _service.GetTable(id);
            if (customer == null)
            {
                return BadRequest("Personel Not Found");
            }
            return Ok(customer);
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            var validator = new CustomerValidation();

            var result = await validator.ValidateAsync(customer);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var customeradd = await _service.AddTable(customer);
            return customeradd;

        }


        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {

            var validator = new CustomerValidation();
            var result = await validator.ValidateAsync(customer);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var customerupdate = await _service.UpdateTable(customer);
            return customerupdate;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteTableId(int id)
        {
            var customerdelete = await _service.DeleteTable(id);
            return customerdelete;
        }

    }
}
