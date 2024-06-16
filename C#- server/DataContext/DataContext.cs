using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interface;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Repository.Entities.Task> Tasks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<LanguageForEmployee> LanguageForEmployees { get; set;   }

        public void save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=LAPTOP-UJ6F34EO;database=TaskManagement3;TrustServerCertificate=True;trusted_connection=true");
        }
    }
}