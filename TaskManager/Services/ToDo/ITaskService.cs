using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Services.ToDo
{
    internal interface ITaskService
    {
        void CreateTask();
        void ShowUserTasks();
        void DeleteTask();
        void EditTask();
    }
}
