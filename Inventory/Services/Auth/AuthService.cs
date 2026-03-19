using Inventory.Data;
using Inventory.Models;

namespace Inventory.Services.Auth
{
    internal class AuthService : IAuthService
    {
        DataContext _db = new DataContext();
        public static User? CurrentUser { get; private set; }

        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrEmpty(username))
                throw new Exception("Username is required!");

            Console.Write("Enter email");
            string email = Console.ReadLine();

            if (string.IsNullOrEmpty(email))
                throw new Exception("Email is required!");

            Console.Write("Enter Password");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
                throw new Exception("Password is required!");

            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User()
            {
                Username = username,
                Email = email,
                Password = HashedPassword
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("Registered Successfully");

        }

        public void Login()
        {
            Console.Write("Enter email");
            string email = Console.ReadLine();

            if (string.IsNullOrEmpty(email))
                throw new Exception("Email is required!");

            Console.Write("Enter Password");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
                throw new Exception("Password is required!");

            var user =_db.Users.FirstOrDefault(s => s.Email == email);
            if (user == null) throw new Exception("Invalid email or password!");

            bool IsPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if(!IsPasswordCorrect)
                throw new Exception("Invalid email or password!");

            Console.WriteLine("Logged in successfully!");

            CurrentUser = user;    
        }
    }
}
