using AutoMapper;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.ViewModels;
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
            CreateMap<TestAppointment, TestAppointmentVM>().ReverseMap();
            CreateMap<TestAppointment, EditTestAppointmentVM>().ReverseMap();
            CreateMap<TestRecord, TestRecordVM>().ReverseMap();
            CreateMap<TestRecord, DetailsTestRecordVM>().ReverseMap();

        }
    }
}
