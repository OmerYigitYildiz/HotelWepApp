using HotelApplication.Models;
using HotelApplication.Models.Response;
using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Services.BaseServices
{
    public interface IReservedService
    {
        Task<List<Reserved>> GetAllTable();
        Task<Reserved> GetTable(Guid id);
        Task<ReservedResponseModel> AddTable(ReservedModel reservedModel);
        Task<ReservedUpdateModel> UpdateTable(ReservedUpdateModel reservedUpdateModel);
        Task<Reserved> DeleteTable(Guid id);
        Task<IEnumerable<Reserved>> GetAllWithRoomsAsync();
    }
}
