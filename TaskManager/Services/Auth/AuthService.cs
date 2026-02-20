using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Services.Auth
{
    internal class AuthService : IAuthService
    {

        private readonly DataContext _db;
        public AuthService(DataContext db) => _db = db;
        public static User? CurrentUser { get; private set; } = null;


        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username is required");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new Exception("Invalid email format");
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new Exception("Min password length is 8!");

            var userExists = _db.Users.Any(u => u.Email == email);
            if (!userExists) throw new Exception("Email already exists!");

            User user = new User()
            {
                Password = password,
                Username = email,
                Email = email,
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("User registered successfully!");
        }
        public void Login()
        {
            Console.WriteLine("Enter email: ");
            var email = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();

            var user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null) throw new Exception("User not found");
            if(user != null)
            {
                CurrentUser = user;
                Console.WriteLine("Logged in successfully!");
            }
        }
        public void Logout()
        {
            CurrentUser = null;
            Console.WriteLine("You have been logged out");
        }

        public void ChangePassword()
        {
            if (CurrentUser == null) throw new Exception("You should be logged in");

            Console.WriteLine("Please enter old Password");
            var oldPass = Console.ReadLine();

            Console.WriteLine("Please enter new Password");
            var newPass = Console.ReadLine();

            if (oldPass != CurrentUser.Password) throw new Exception("Incorrect Password");
            CurrentUser.Password = newPass;

            _db.SaveChanges();
            Console.WriteLine("Password changed successfully.");
        }

    }
}
