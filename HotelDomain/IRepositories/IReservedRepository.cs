using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomain.IRepositories.IBaseRepositories
{
    public interface IReservedRepository : IRepostiory<Reserved>
    {
        //Task<List<Reserved>> GetReservedWithRoomsAsync();
        Task<IEnumerable<Reserved>> GetAllWithRoomsAsync();
        Task<Reserved> GetByIdWithRoomAsync(Guid id);
        //Task<IEnumerable<Reserved>> GetAllAsync(Func<Reserved, bool> predicate);
    }

}
