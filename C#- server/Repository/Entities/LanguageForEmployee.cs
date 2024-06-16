using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class LanguageForEmployee
    {
        public int Id { get; set; } 
        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int Level { get; set; }
    }
}
