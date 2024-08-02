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
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {

        private HotelDbContext _context;
        public AuthorRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAuthorWithBooksAsync()
        {
            return await _context.Authors
                .Include(a => a.Books) // Yazarın kitaplarını da dahil et
                .ToListAsync(); // Veritabanından liste olarak al
        }
    }
}
