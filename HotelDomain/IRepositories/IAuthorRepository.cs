using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDomain.IRepositories.IBaseRepositories;

namespace HotelDomain.IRepositories
{
    public interface IAuthorRepository : IRepostiory<Author>
    {
        Task<List<Author>> GetAuthorWithBooksAsync();
    }
}
