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
        Task<Customer> AddTable(Customer customer);
        Task<Customer> UpdateTable(Customer customer);
        Task<Customer> DeleteTable(int id);
    }
}
