using HotelApplication.Services.BaseServices;
using HotelInfrastructure.Repositories;
using HotelDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDomain.IRepositories;
using HotelApplication.Mapper;
using HotelApplication.Models;


namespace HotelApplication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAllTable()
        {
            var Customer = await _repository.GetAllAsync();
            return Customer;
        }

        public async Task<Customer> GetTable(Guid id)
        {
            var Customer = await _repository.GetByIdAsync(id);
            var user = HotelMapper.Mapper.Map<Customer>(Customer);

            return Customer;

        }
        public async Task<CustomerResponseModel> AddTable(CustomerModel customerModel)
        {
            var user = HotelMapper.Mapper.Map<Customer>(customerModel);
            await _repository.AddAsync(user);
            return HotelMapper.Mapper.Map<CustomerResponseModel>(user);
        }



        public async Task<CustomerUpdateModel> UpdateTable(CustomerUpdateModel customerUpdateModel)
        {
            var user = HotelMapper.Mapper.Map<Customer>(customerUpdateModel);
            await _repository.UpdateAsync(user);
            return HotelMapper.Mapper.Map<CustomerUpdateModel>(user);
        }


        public async Task<Customer> DeleteTable(Guid id)
        {
            var Customer = await _repository.DeleteAsync(id);
            return Customer;


        }
    }
}
