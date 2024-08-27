using AutoMapper;
using HotelDomain.Entities;
using HotelApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApplication.Models.Response;

namespace HotelApplication.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<Customer, CustomerResponseModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Customer, CustomerUpdateModel>().ReverseMap();

            CreateMap<Room, RoomResponseModel>().ReverseMap();
            CreateMap<Room, RoomModel>().ReverseMap();
            CreateMap<Room, RoomUpdateModel>().ReverseMap();

            CreateMap<Reserved, ReservedResponseModel>().ReverseMap();
            CreateMap<Reserved, ReservedModel>().ReverseMap();
            CreateMap<Reserved, ReservedUpdateModel>().ReverseMap();

        }
    }
}
