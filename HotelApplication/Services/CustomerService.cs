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

        public async Task<Customer> GetTable(int id)
        {
            var Customer = await _repository.GetByIdAsync(id);
            //var user = MainProjectMapper.Mapper.Map<PersonelResponseModel>(Customer);

            return Customer;

        }
        //public async Task<CustomerResponseModel> AddTable(CustomerModel model)
        public async Task<Customer> AddTable(Customer Customer)
        {
            await _repository.AddAsync(Customer);
            return Customer;
        }

        public async Task<Customer> UpdateTable(Customer Customer)
        {
            await _repository.UpdateAsync(Customer);
            return Customer;
        }

        public async Task<Customer> DeleteTable(int id)
        {
            var Customer = await _repository.DeleteAsync(id);
            return Customer;


        }
    }
}
