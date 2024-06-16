using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }//מצב המשימה :1-תהלך...
        public int Level { get; set; }//רמת המשימה התאמה לרמת- שנות נסיון של העובד
        public int EmployeeId { get; set; }
        public int LanguageId { get; set; }
        public DateTime DeadLine { get; set; }

    }
}
