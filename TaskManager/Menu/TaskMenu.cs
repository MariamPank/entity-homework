using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Services.ToDo;

namespace TaskManager.Menu
{
    internal class TaskMenu
    {
        private static readonly ITaskService _taskService;

        public static void TaskStart()
        {
            while (true)
            {
                Console.WriteLine("=========== Task menu ==============");
                Console.WriteLine("1. create task");
                Console.WriteLine("2. delete task");
                Console.WriteLine("3. edit task");
                Console.WriteLine("4. show user task");
                Console.WriteLine("5. Exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                if (key == "1")
                {
                    Console.Clear();
                    _taskService.CreateTask();
                }
                else if (key == "2")
                {
                    Console.Clear();
                    _taskService.DeleteTask();
                }
                else if (key == "3")
                {
                    Console.Clear();
                    _taskService.EditTask();
                }
                else if (key == "4")
                {
                    Console.Clear();
                    _taskService.ShowUserTasks();
                }
                else if (key == "5")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid key!");
                }
            }
        }



    }
}
