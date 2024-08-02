using HotelDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApplication.Mapper;
using LibraryApplication.Models;
using LibraryApplication.Services.BaseServices;
using LibraryApplication.Validations;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBook()
        {
            var books = await _service.GetAllTable();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var books = await _service.GetTable(id);

            if (books == null)
            {
                return BadRequest("Task Not Found");
            }
            else
            {
                return Ok(books);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(BookModel model)
        {

            var validator = new BookValidation();
            var result = await validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var bookadd = await _service.AddTable(model);
            return LibraryMapper.Mapper.Map<Book>(bookadd);
        }
        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(BookUpdateModel book)
        {
            var validator = new BookUpdateModelValidation();
            var result = await validator.ValidateAsync(book);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var bookupdate = await _service.UpdateTable(book);
            return LibraryMapper.Mapper.Map<Book>(bookupdate);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var books = await _service.DeleteTable(id);

            if (books == null)
            {
                return BadRequest("Task Not Found");
            }
            else
            {
                return Ok(books);
            }

        }

    }
}
