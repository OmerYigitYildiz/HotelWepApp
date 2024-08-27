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
    public interface IAuthorService
    {
        Task<List<Author>> GetAllTable();
        Task<Author> GetTable(Guid id);
        Task<AuthorResponseModel> AddTable(AuthorModel authorModel);
        Task<AuthorUpdateModel> UpdateTable(AuthorUpdateModel authorUpdateModel);
        Task<Author> DeleteTable(Guid id);
        Task<List<Author>> GetAuthorWithBooksAsync();
    }
}
