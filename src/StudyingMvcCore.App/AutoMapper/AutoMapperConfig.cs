using AutoMapper;
using StudyingMvcCore.App.ViewModels;
using StudyingMvcCore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyingMvcCore.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<ToDo, ToDoViewModel>().ReverseMap();
        }
    }
}
