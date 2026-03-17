using TweetTweet.Services;

namespace TweetTweet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsersService _usersService = new UsersService();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("========== Twitter ==========");
                Console.WriteLine("1. register");
                Console.WriteLine("2. login");
                Console.WriteLine("3. show users");
                Console.ResetColor();

                Console.WriteLine("");
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                if (key == "1")
                {
                    Console.Clear();
                    _usersService.Register();
                }
                else if (key == "2")
                {
                    Console.Clear();
                    _usersService.Login();
                }
                else if (key == "3")
                {
                    Console.Clear();
                    _usersService.ShowUsers();
                }
                else break;
            }
        }
    }
}
