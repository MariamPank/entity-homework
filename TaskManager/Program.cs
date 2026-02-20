using TaskManager.Menu;
using TaskManager.Services.Auth;

namespace OneToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("======== Task manager ==========");
                Console.WriteLine("1. auth menu");
                Console.WriteLine("2. todos menu");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                if (key == "1")
                {
                    Console.Clear();
                    AuthMenu.AuthStart();
                }
                else if (key == "2")
                {

                    if (AuthService.CurrentUser == null)
                    {
                        Console.WriteLine("User is not logged in!");
                    }
                    else
                    {
                        Console.Clear();
                        TaskMenu.TaskStart();
                    }
                }
                else break;
            }
        }
    }
}
