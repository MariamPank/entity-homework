using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Services.Auth;

namespace TaskManager.Services.ToDo
{
    internal class ToDo : ITaskService
    {
        private readonly DataContext _db = new DataContext();

        public void CreateTask()
        {
            if (AuthService.CurrentUser == null)
                throw new Exception("Please log in");

            Console.WriteLine("Please enter Task Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter Description: ");
            var desc = Console.ReadLine();

            Console.WriteLine("Please enter the Due Date in days: ");
            var dueDays = int.Parse(Console.ReadLine());

            if (dueDays < 0) throw new Exception("Please enter the correct quantity of days");

            var dueDate = DateTime.Now.AddDays(dueDays);

            TaskToDo newTask = new TaskToDo()
            {
                UserId = AuthService.CurrentUser.Id,
                Name = name,
                Description = desc,
                DueDate = dueDate,
            };

            _db.Tasks.Add(newTask);
            _db.SaveChanges();
            Console.WriteLine("Task created successfully!");

        }
        public void ShowUserTasks()
        {
            if (AuthService.CurrentUser == null)
                throw new Exception("Please log in");

            var toDos =_db.Tasks.Where(u => u.UserId == AuthService.CurrentUser.Id).ToList();

            foreach(var t in toDos)
            {
                Console.WriteLine($"ID: {t.Id}, Name: {t.Name}, Desc: {t.Description}, Due date: {t.DueDate}");
            }
        }
        public void DeleteTask()
        {
            if (AuthService.CurrentUser == null)
                throw new Exception("Please log in");

            ShowUserTasks();
            Console.WriteLine("Please enter the Task Id: ");
            var taskId = int.Parse(Console.ReadLine());

            var taskToDo = _db.Tasks.FirstOrDefault(u => u.Id == taskId && u.UserId== AuthService.CurrentUser.Id);

            if (taskToDo == null) throw new Exception("Task not found!");

            _db.Tasks.Remove(taskToDo);
            _db.SaveChanges();
            Console.WriteLine("Task deleted successfully.");
        }
        public void EditTask()
        {
            if (AuthService.CurrentUser == null)
                throw new Exception("Please log in");

            ShowUserTasks();
            Console.WriteLine("Please enter the Task Id: ");
            var taskId = int.Parse(Console.ReadLine());

            var taskToDo = _db.Tasks.FirstOrDefault(u => u.Id == taskId && u.UserId == AuthService.CurrentUser.Id);

            Console.WriteLine("Please enter the Task Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter the Task Description: ");
            var desc = Console.ReadLine();

            Console.WriteLine("Please enter the Task due date in days: ");
            var days = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
                taskToDo.Name = name;
            if (!string.IsNullOrEmpty(desc))
                taskToDo.Description = desc;
            if (!string.IsNullOrEmpty(days))
                taskToDo.DueDate = DateTime.UtcNow.AddDays(int.Parse(days));

            _db.SaveChanges();
            Console.WriteLine("Task updated successfully.");

        }
    }
}
 