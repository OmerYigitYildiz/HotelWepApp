using AutoMapper;
using HotelDomain.Entities;
using HotelApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<Customer, CustomerResponseModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Room, RoomResponseModel>().ReverseMap();
            CreateMap<Room, RoomModel>().ReverseMap();

        }
    }
}
