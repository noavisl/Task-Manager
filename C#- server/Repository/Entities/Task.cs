using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Repository.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Level { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }    
        public virtual Language language { get; set; }
        public DateTime DeadLine { get; set; }


    }
}
