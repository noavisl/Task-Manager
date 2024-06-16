using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Repository.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {

        private readonly IContext context;
        public EmployeeRepository(IContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee entity)
        {

            var existingEmployee = this.context.Employees.FirstOrDefault(x => x.Email == entity.Email);
            if (existingEmployee != null)
            {
                return null; // או לזרוק חריגת עסקית אם זה מתאים לך
            }
            else
            {
                this.context.Employees.Add(entity);
                this.context.save();
                return entity;
            }
        }

        public void Delete(int id)
        {
            var e = this.context.Employees.FirstOrDefault(x => x.Id == id);
            this.context.Employees.Remove(e);
            this.context.save();
        }

        public Employee Get(int id)
        {
            return this.context.Employees.Include((x) => x.LanguageForEmployees).FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetAll()
        {
            return this.context.Employees.ToList();
        }

        public Employee Update(int id, Employee entity)
        {
            var e = context.Employees.Include(x => x.LanguageForEmployees).FirstOrDefault(x => x.Id == id);
            e.FirstName = entity.FirstName;
            e.LastName = entity.LastName;
            e.Status = entity.Status;
            e.Email = entity.Email;
            e.Experience = entity.Experience;
            e.Password = entity.Password;
            e.Tasks = entity.Tasks;
            e.LanguageForEmployees = entity.LanguageForEmployees;
            e.Vacations=entity.Vacations;
            e.ManagerId = entity.ManagerId;
            this.context.save();
            return e;
        }




    }
}
