using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        public string TaskName { get; set; }

        public bool Status { get; set; }
    }
}
