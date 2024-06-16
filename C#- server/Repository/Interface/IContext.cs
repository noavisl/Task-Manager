using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IContext
    {
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Vacation> Vacations {  get; set; } 
        public DbSet<LanguageForEmployee> LanguageForEmployees { get; set; }
        


        public void save();
    }
}
