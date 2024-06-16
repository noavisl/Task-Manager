using AutoMapper;
using Common.Dto;
using Repository.Entities;

namespace Repository
{
    public class MapperProfile:Profile
    {
        public MapperProfile() { 
           CreateMap<Employee,EmployeeDto>().ReverseMap();
           CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Vacation, VacationDto>().ReverseMap();
            CreateMap<Entities.Task, TaskDto>().ReverseMap();
            CreateMap<LanguageForEmployee, LanguageForEmployeeDto>().ReverseMap();  
        }  
    }
}