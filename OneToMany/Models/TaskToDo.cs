using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    internal class TaskToDo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
