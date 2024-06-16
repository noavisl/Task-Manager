using Common.Dto;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interface;
using Repository.Repositories;
using Service.Interface;
using Service.Services;
using Service.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public static class ExtentionService
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddRepository();
            service.AddScoped<IService<EmployeeDto>, EmployeeService>();
            service.AddScoped<IService<TaskDto>, TaskService>();
            service.AddScoped<IService<LanguageDto>, LanguageService>();
            service.AddScoped<IService<VacationDto>, VacationService>();
            service.AddScoped<IService<LanguageForEmployeeDto>, LanguageForEmployeeService>();

            service.AddAutoMapper(typeof(MapperProfile));
            return service;
                 
        }
    }
}
