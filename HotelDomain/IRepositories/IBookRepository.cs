using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDomain.Entities;
using HotelDomain.Entities;
using HotelDomain.IRepositories.IBaseRepositories;

namespace HotelDomain.IRepositories
{
    public interface IBookRepository : IRepostiory<Book>
    {
    }
}
