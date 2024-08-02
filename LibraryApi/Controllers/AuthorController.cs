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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthorTable()
        {
            var author = await _service.GetAllTable();
            return Ok(author);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorTable(int id)
        {
            var author = await _service.GetTable(id);
            if (author == null)
            {
                return BadRequest("Personel Not Found");
            }
            return Ok(author);
        }


        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(AuthorModel model)
        {
            var validator = new AuthorValidation();

            var result = await validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var authoradd = await _service.AddTable(model);
            return LibraryMapper.Mapper.Map<Author>(authoradd);

        }


        [HttpPut]
        public async Task<ActionResult<Author>> Author(AuthorUpdateModel author)
        {

            var validator = new AuthorUpdateModelValidation();
            var result = await validator.ValidateAsync(author);

            if (!result.IsValid)
            {
                return UnprocessableEntity(result);
            }

            var authorupdate = await _service.UpdateTable(author);
            return LibraryMapper.Mapper.Map<Author>(authorupdate);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteTableId(int id)
        {
            var authordelete = await _service.DeleteTable(id);
            return authordelete;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthorWithBooks()
        {
            var authorsWithBooks = await _service.GetAuthorWithBooksAsync();
            return Ok(authorsWithBooks);
        }

    }

}


