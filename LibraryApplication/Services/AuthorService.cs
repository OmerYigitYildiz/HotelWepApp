using HotelDomain.Entities;
using HotelDomain.Entities;
using HotelDomain.IRepositories;
using LibraryApplication.Mapper;
using LibraryApplication.Models;
using LibraryApplication.Models.Response;
using LibraryApplication.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Author>> GetAllTable()
        {
            var Author = await _repository.GetAllAsync();
            return Author;
        }

        public async Task<Author> GetTable(Guid id)
        {
            var Author = await _repository.GetByIdAsync(id);
            var user = LibraryMapper.Mapper.Map<Author>(Author);

            return Author;

        }
        public async Task<AuthorResponseModel> AddTable(AuthorModel authorModel)
        {
            var user = LibraryMapper.Mapper.Map<Author>(authorModel);
            await _repository.AddAsync(user);
            return LibraryMapper.Mapper.Map<AuthorResponseModel>(user);
        }



        public async Task<AuthorUpdateModel> UpdateTable(AuthorUpdateModel authorUpdateModel)
        {
            var user = LibraryMapper.Mapper.Map<Author>(authorUpdateModel);
            await _repository.UpdateAsync(user);
            return LibraryMapper.Mapper.Map<AuthorUpdateModel>(user);
        }


        public async Task<Author> DeleteTable(Guid id)
        {
            var Author = await _repository.DeleteAsync(id);
            return Author;
        }

        public async Task<List<Author>> GetAuthorWithBooksAsync()
        {
            var authorsWithBooks = await _repository.GetAuthorWithBooksAsync();
            return authorsWithBooks;
        }
    }
}
