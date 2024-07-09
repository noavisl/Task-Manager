﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Status { get; set; }

        public int? ManagerId { get; set; }
        public int? Experience { get; set; } // 1-5

        public Dictionary<int,int>? LanguageInt { get; set; } = new Dictionary<int, int>();

        public ICollection<VacationDto> ?Vacations{ get; set; }

    }
}
