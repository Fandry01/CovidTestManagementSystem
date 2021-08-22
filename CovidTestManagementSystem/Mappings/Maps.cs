using AutoMapper;
using CovidTestManagementSystem.Data;
using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<TestTypes, TestTypeVM>().ReverseMap();
            CreateMap<Nurse, NursesVM>().ReverseMap();

        }
    }
}
