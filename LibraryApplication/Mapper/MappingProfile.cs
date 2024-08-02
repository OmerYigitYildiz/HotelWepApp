using AutoMapper;
using HotelDomain.Entities;
using LibraryApplication.Models;
using LibraryApplication.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Author, AuthorResponseModel>().ReverseMap();
            CreateMap<Author, AuthorUpdateModel>().ReverseMap();

            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, BookResponseModel>().ReverseMap();
            CreateMap<Book, BookUpdateModel>().ReverseMap();
        }
    }
}
