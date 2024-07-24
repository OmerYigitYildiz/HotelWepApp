using HotelDomain.IRepositories;
using HotelDomain.Entities;
using HotelInfrastructure.Data;
using HotelInfrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInfrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        private HotelDbContext _context;
        public CustomerRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
