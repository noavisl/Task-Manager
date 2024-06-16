using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public static class ExtentionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            //יוצר אובייקט מאחורי הקלעים-הזרקת תלויות
            service.AddScoped<IRepository<Employee>, EmployeeRepository>();
            service.AddScoped<IRepository<Entities.Task >, TaskRepository>();
            service.AddScoped<IRepository<Language>, LanguageRepository>();
            service.AddScoped<IRepository<Vacation>, VacationRepository>();
            service.AddScoped<IRepository<LanguageForEmployee>, LanguageForEmployeeRepository>();

            return service;

                 
        }
    }
}
