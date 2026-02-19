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

    }
}
