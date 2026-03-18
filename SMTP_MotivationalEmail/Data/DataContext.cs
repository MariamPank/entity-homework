using Microsoft.EntityFrameworkCore;
using SMTP_MotivationalEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTP_MotivationalEmail.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=mssql-206521-0.cloudclusters.net,10100;Initial Catalog=SMTPComp;User ID=mp;Password=Mp123456;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False",

                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailLog>()
                .HasOne(el => el.Employee)
                .WithMany(e => e.EmailLogs)
                .HasForeignKey(el => el.EmployeeId);
        }
    }
}
