using HotelApplication.Models;
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
        Task<RoomResponseModel> AddTable(RoomModel roomModel);
        Task<RoomResponseModel> UpdateTable(RoomModel roomModel);
        Task<Room> DeleteTable(int id);
    }
}
