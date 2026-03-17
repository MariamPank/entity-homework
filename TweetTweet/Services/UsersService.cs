using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetTweet.Data;
using TweetTweet.Models;

namespace TweetTweet.Services
{
    internal class UsersService
    {
        DataContext _db = new DataContext();


        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username is requierd!");

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is requierd!");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is requierd!");

            User user = new User()
            {
                Username = username,
                Email = email,
                Password = password
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("Registered successfully.");
        }

        public void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is requierd!");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is requierd!");

            var user = _db.Users
                .FirstOrDefault(e => e.Email == email && e.Password == password);

            if (user == null) throw new Exception("User not found!");

            Console.WriteLine($"ID: {user.Id}, username: {user.Username},  email: {user.Email}");
        }

        public void ShowUsers()
        {
            var users = _db.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, username: {user.Username},  email: {user.Email}");
            }
        }
    }
}
