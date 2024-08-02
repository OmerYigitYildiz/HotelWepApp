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
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetAllTable()
        {
            var Book = await _repository.GetAllAsync();
            return Book;
        }

        public async Task<Book> GetTable(int id)
        {
            var Book = await _repository.GetByIdAsync(id);
            var user = LibraryMapper.Mapper.Map<Book>(Book);

            return Book;

        }

        public async Task<BookResponseModel> AddTable(BookModel bookModel)
        {
            var user = LibraryMapper.Mapper.Map<Book>(bookModel);
            await _repository.AddAsync(user);
            return LibraryMapper.Mapper.Map<BookResponseModel>(user);
        }

        public async Task<BookUpdateModel> UpdateTable(BookUpdateModel bookUpdateModel)
        {
            var user = LibraryMapper.Mapper.Map<Book>(bookUpdateModel);
            await _repository.UpdateAsync(user);
            return LibraryMapper.Mapper.Map<BookUpdateModel>(user);
        }

        public async Task<Book> DeleteTable(int id)
        {
            var Book = await _repository.DeleteAsync(id);
            return Book;


        }
    }
}
