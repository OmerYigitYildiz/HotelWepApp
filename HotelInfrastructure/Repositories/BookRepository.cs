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
using HotelDomain.Entities;

namespace HotelInfrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        private HotelDbContext _context;
        public BookRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
