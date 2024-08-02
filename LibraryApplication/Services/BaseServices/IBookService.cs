using HotelDomain.Entities;
using HotelDomain.Entities;
using LibraryApplication.Models;
using LibraryApplication.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services.BaseServices
{
    public interface IBookService
    {
        Task<List<Book>> GetAllTable();
        Task<Book> GetTable(int id);
        Task<BookResponseModel> AddTable(BookModel bookModel);
        Task<BookUpdateModel> UpdateTable(BookUpdateModel bookUpdateModel);
        Task<Book> DeleteTable(int id);
    }
}
