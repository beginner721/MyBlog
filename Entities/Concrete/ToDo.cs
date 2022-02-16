using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Job { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }  
    }
}
