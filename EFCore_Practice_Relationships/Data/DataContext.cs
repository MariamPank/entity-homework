using EFCore_Practice_Relationships.Models.OneToMany.BookAuthor;
using EFCore_Practice_Relationships.Models.OneToOne.CompDirector;
using EFCore_Practice_Relationships.Models.OneToOne.StudentPass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Data
{
    internal class DataContext : DbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Director> Directors { get; set; }

        public DbSet<Studnt> Students { get; set; }
        public DbSet<Passport> Passports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=mssql-206521-0.cloudclusters.net,10100;Initial Catalog=EntityRel;User ID=mp;Password=Mp123456;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Company-Director
            modelBuilder.Entity<Director>()
                .HasOne(c => c.Company)
                .WithOne(d => d.Director)
                .HasForeignKey<Company>(d => d.DirectorId);

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.DirectorId)
                .IsUnique();

            //Student-Passport
            modelBuilder.Entity<Studnt>()
                .HasOne(p => p.Passport)
                .WithOne(s => s.Studnt)
                .HasForeignKey<Passport>(s => s.StudntId);

            modelBuilder.Entity<Passport>()
                .HasIndex(p => p.StudntId)
                .IsUnique();

            //Book-Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
