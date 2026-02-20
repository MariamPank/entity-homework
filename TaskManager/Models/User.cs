using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core;

namespace TaskManager.Models
{
    internal class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<TaskToDo> Tasks { get; set; } = new List<TaskToDo>();
    }
}
