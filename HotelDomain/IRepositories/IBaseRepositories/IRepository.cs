using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomain.IRepositories.IBaseRepositories
{
    public interface IRepostiory<TEntity> where TEntity : class
    {
        // Get Functions
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);

        // Put Functions
        Task<TEntity> UpdateAsync(TEntity TEntity);

        // Post Function
        Task<TEntity> AddAsync(TEntity TEntity);

        // Delete Function
        Task<TEntity> DeleteAsync(int id);
    }
}
