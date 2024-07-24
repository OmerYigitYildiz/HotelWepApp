using HotelDomain.IRepositories;
using HotelDomain.Entities;
using HotelInfrastructure.Data;
using HotelInfrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private HotelDbContext _context;
        public RoomRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
