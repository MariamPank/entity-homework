using Entity_HomeWorks_OneToOne.Models.OneToOne.AccountSettings;
using Entity_HomeWorks_OneToOne.Models.OneToOne.CarRegistration;
using Entity_HomeWorks_OneToOne.Models.OneToOne.PersonPassport;
using Entity_HomeWorks_OneToOne.Models.OneToOne.StudentCard;
using Entity_HomeWorks_OneToOne.Models.OneToOne.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Relationships.Models.OneToMany.CategoryProducts;
using Relationships.Models.OneToMany.TeacherStudents;
using Relationships.Models.OneToMany.UserOrders;
using Relationships.Models.OneToMany.VendorAddresses;
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


            //One-to-Many
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Students>()
                .HasOne(o => o.Teacher)
                .WithMany(u => u.Students)
                .HasForeignKey(o => o.TeacherId);

            modelBuilder.Entity<Addresses>()
                .HasOne(o => o.Vendor)
                .WithMany(u => u.VendorAddresses)
                .HasForeignKey (o => o.VendorId);

            modelBuilder.Entity<Products>()
                .HasOne(o => o.Category)
                .WithMany(u => u.Products)
                .HasForeignKey(o => o.CategoryId);

        }
    }
}
