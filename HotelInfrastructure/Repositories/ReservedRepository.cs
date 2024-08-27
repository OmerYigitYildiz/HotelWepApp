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
using Microsoft.EntityFrameworkCore;
using HotelDomain.IRepositories.IBaseRepositories;

namespace HotelInfrastructure.Repositories
{
    public class ReservedRepository : Repository<Reserved>, IReservedRepository
    {
        private HotelDbContext _context;
        public ReservedRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

        // Tüm rezervasyonları oda bilgisiyle birlikte getirir
        public async Task<IEnumerable<Reserved>> GetAllWithRoomsAsync()
        {
            return await _context.Reserveds
                .Include(r => r.Room)
                .ToListAsync();
        }

        // Belirli bir rezervasyonu oda bilgisiyle birlikte getirir
        public async Task<Reserved> GetByIdWithRoomAsync(Guid id)
        {
            return await _context.Reserveds
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        //public async Task<List<Reserved>> GetReservedWithRoomsAsync()
        //{
        //    return await _context.Reserveds
        //        .Include(a => a.Room) // oda bilgilerini de dahil et
        //        .ToListAsync(); // Veritabanından liste olarak al
        //}
    }
}
