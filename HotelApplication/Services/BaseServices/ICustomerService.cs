using HotelApplication.Models;
using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Services.BaseServices
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllTable();
        Task<Customer> GetTable(int id);
        Task<CustomerResponseModel> AddTable(CustomerModel customerModel);
        Task<CustomerResponseModel> UpdateTable(CustomerModel customerModel);
        Task<Customer> DeleteTable(int id);
    }
}
