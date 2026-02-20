using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.Auth;

namespace TaskManager.Menu
{
    internal class AuthMenu
    {
        private static AuthService _authService = new AuthService();

        public static void AuthStart()
        {
            while (true)
            {
                Console.WriteLine("========= Auth menu ============");
                Console.WriteLine("1. register");
                Console.WriteLine("2. login");
                Console.WriteLine("3. change password");
                Console.WriteLine("4. Exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                if (key == "1")
                {
                    Console.Clear();
                    _authService.Register();
                }
                else if (key == "2")
                {
                    Console.Clear();
                    _authService.Login();
                }
                else if (key == "3")
                {
                    Console.Clear();
                    _authService.ChangePassword();
                }
                else if (key == "4")
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
