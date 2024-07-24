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
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<Customer, CustomerResponseModel>().ReverseMap();
        
        }
    }
}
