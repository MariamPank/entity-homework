using Microsoft.EntityFrameworkCore;
using SMTP_MotivationalEmail.Data;
using SMTP_MotivationalEmail.Models;
using SMTP_MotivationalEmail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTP_MotivationalEmail.Services
{
    internal class CompanyService
    {
        private readonly DataContext _db = new DataContext();
        private readonly GmailEmailService _emailService = new GmailEmailService();

        public void AddEmployee()
        {
            Console.Write("Enter employee full name: ");
            string fullName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine("Full name is required.");
                return;
            }

            Console.Write("Enter employee email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email is required.");
                return;
            }

            var employee = new Employee
            {
                FullName = fullName,
                Email = email,
            };

            _db.Employees.Add(employee);
            _db.SaveChanges();

            Console.WriteLine("Employee added successfully.");
        }

        public void ShowEmployees()
        {

            foreach (var employee in _db.Employees)
            {
                Console.WriteLine($"  Employee Id: {employee.Id}, Name: {employee.FullName}, Email: {employee.Email}");
            }   
        }

        public void SendMotivationEmailToAll()
        {

            if (!_db.Employees.Any())
            {
                Console.WriteLine("This company has no employees.");
                return;
            }

            Console.Write("Enter email subject: ");
            string subject = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject is required.");
                return;
            }

            Console.Write("Enter motivation email text: ");
            string body = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(body))
            {
                Console.WriteLine("Body is required.");
                return;
            }

            foreach (var employee in _db.Employees)
            {
                try
                {
                    _emailService.SendEmail(employee.Email, subject, body);

                    var emailLog = new EmailLog
                    {
                        Subject = subject,
                        Body = body,
                        ReceiverEmail = employee.Email,
                        SentAt = DateTime.Now,
                        EmployeeId = employee.Id
                    };

                    _db.EmailLogs.Add(emailLog);

                    Console.WriteLine($"Email sent to {employee.FullName} - {employee.Email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email to {employee.Email}");
                    Console.WriteLine(ex.Message);
                }
            }

            _db.SaveChanges();
            Console.WriteLine("Sending process completed.");
        }

        public void ShowEmailLogs()
        {
            var logs = _db.EmailLogs
                .Include(l => l.Employee)
                .ToList();

            if (!logs.Any())
            {
                Console.WriteLine("No email logs found.");
                return;
            }

            foreach (var log in logs)
            {
                Console.WriteLine($"Log Id: {log.Id}");
                Console.WriteLine($"Employee: {log.Employee.FullName}");
                Console.WriteLine($"To: {log.ReceiverEmail}");
                Console.WriteLine($"Subject: {log.Subject}");
                Console.WriteLine($"Body: {log.Body}");
                Console.WriteLine($"Sent At: {log.SentAt}");
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}