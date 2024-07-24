using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Services.BaseServices
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllTable();
        Task<Room> GetTable(int id);
        Task<Room> AddTable(Room room);
        Task<Room> UpdateTable(Room room);
        Task<Room> DeleteTable(int id);
    }
}
