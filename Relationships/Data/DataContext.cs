using Entity_HomeWorks_OneToOne.Models.OneToOne.AccountSettings;
using Entity_HomeWorks_OneToOne.Models.OneToOne.CarRegistration;
using Entity_HomeWorks_OneToOne.Models.OneToOne.PersonPassport;
using Entity_HomeWorks_OneToOne.Models.OneToOne.StudentCard;
using Entity_HomeWorks_OneToOne.Models.OneToOne.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=mssql-206521-0.cloudclusters.net,10100;Initial Catalog=ForExercises;User ID=mp;Password=Mp123456;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Car>().HasKey(x => x.Id);
            modelBuilder.Entity<Car>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>().Property(x => x.Id).ValueGeneratedOnAdd();


            // One-to-One
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<Student>()
                .HasOne(u=>u.Card)
                .WithOne(p => p.Student)
                .HasForeignKey<Card>(p => p.StudentId);

            modelBuilder.Entity<Person>()
                .HasOne(u => u.Passport)
                .WithOne(p => p.Person)
                .HasForeignKey<Passport>(p => p.PersonId);

            modelBuilder.Entity<Car>()
                .HasOne(u => u.Registration)
                .WithOne(p => p.Car)
                .HasForeignKey<Registration>(p=>p.CarId);

            modelBuilder.Entity<Account>()
                .HasOne(u => u.Settings)
                .WithOne(p => p.Account)
                .HasForeignKey<Settings>(p => p.AccountId);

        }
    }
}
