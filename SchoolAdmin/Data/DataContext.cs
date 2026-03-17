using Microsoft.EntityFrameworkCore;
using SchoolAdmin.Models;

namespace SchoolAdmin.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<PupilClass> PupilClases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=mssql-206521-0.cloudclusters.net,10100;Initial Catalog=SchoolAdmin;User ID=mp;Password=Mp123456;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
