using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class LanguageForEmployeeDto
    {
        public int Id { get; set; } 
        public int IdEmployee { get; set; }

        public int LanguageId { get; set; }

        public int Level { get; set; }
    }
}
