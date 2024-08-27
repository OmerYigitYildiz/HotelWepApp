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
        Task<Room> GetTable(Guid id);
        Task<RoomResponseModel> AddTable(RoomModel roomModel);
        Task<RoomUpdateModel> UpdateTable(RoomUpdateModel roomUpdateModel);
        Task<Room> DeleteTable(Guid id);
    }
}
