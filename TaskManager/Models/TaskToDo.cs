using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core;

namespace TaskManager.Models
{
    internal class TaskToDo : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
