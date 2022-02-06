using AutoMapper;
using RESTfulAPI.Data;
using RESTfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<CarModel, CarDTO>().ReverseMap();
            CreateMap<CarModel, CreateCarDTO>().ReverseMap();
        }
    }
}
