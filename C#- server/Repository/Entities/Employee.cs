using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int ManagerId { get; set; }
        public int Experience { get; set; } // 1-5
        public ICollection<Task> Tasks { get; set; }
        public ICollection<LanguageForEmployee> LanguageForEmployees { get; set; }   

        public  ICollection<Vacation> Vacations { get; set; }   
    }
}
