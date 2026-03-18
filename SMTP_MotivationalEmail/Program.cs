using SMTP_MotivationalEmail.Services;

namespace SMTP_MotivationalEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompanyService companyService = new CompanyService();

            while (true)
            {
                Console.WriteLine("====== MENU ======");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Show employees");
                Console.WriteLine("3. Send motivation email to all employees of company");
                Console.WriteLine("4. Show email logs");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            companyService.AddEmployee();
                            break;
                        case "2":
                            companyService.ShowEmployees();
                            break;
                        case "3":
                            companyService.SendMotivationEmailToAll();
                            break;
                        case "4":
                            companyService.ShowEmailLogs();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:");
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }
    }
}