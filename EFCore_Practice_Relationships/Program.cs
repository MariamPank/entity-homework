using EFCore_Practice_Relationships.Data;
using EFCore_Practice_Relationships.Models.OneToMany.BookAuthor;
using EFCore_Practice_Relationships.Models.OneToOne.CompDirector;
using EFCore_Practice_Relationships.Models.OneToOne.StudentPass;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Practice_Relationships
{
    internal class Program
    {
        private readonly static DataContext _db = new DataContext();
        static void Main(string[] args)
        {
            var d1 = new Director { Name = "Mariam" };
            var d2 = new Director { Name = "Nino" };
            _db.Directors.AddRange(d1, d2);
            _db.SaveChanges();

            var c1 = new Company { Name = "AgriGeorgia", Type = "LLC", DirectorId = d1.Id };
            var c2 = new Company { Name = "Epam", Type = "JSC", DirectorId = d2.Id };
            _db.Companies.AddRange(c1, c2);
            _db.SaveChanges();

            var resultD = _db.Directors
            .Include(s => s.Company)
            .FirstOrDefault();

            Console.WriteLine("Director Information:");
            Console.WriteLine($"Id: {resultD.Id}");
            Console.WriteLine($"Name: {resultD.Name}");
            Console.WriteLine($"Company Id: {resultD.Company.Id}");
            Console.WriteLine();


            var s1 = new Studnt { Name = "Alex" };
            var s2 = new Studnt { Name = "Ana" };
            _db.Students.AddRange(s1, s2);
            _db.SaveChanges();

            var p1 = new Passport { PassNumber = "JKN21414", StudntId = s1.Id };
            var p2 = new Passport { PassNumber = "WRJN2141", StudntId = s2.Id };
            _db.Passports.AddRange(p1, p2);
            _db.SaveChanges();


            var resultS = _db.Students
            .Include(s => s.Passport)
            .FirstOrDefault();

            Console.WriteLine("Student Information:");
            Console.WriteLine($"Id: {resultS.Id}");
            Console.WriteLine($"Name: {resultS.Name}");
            Console.WriteLine($"Passport Number: {resultS.Passport.PassNumber}");
            Console.WriteLine();



            var author = new Author
            {
                Name = "George Orwell",
                Books = new List<Book>
                {
                new Book { Name = "1984", Genre = "Dystopian" },
                new Book { Name = "Animal Farm", Genre = "Political Satire" }
                }
            };

            Console.WriteLine($"Author: {author.Name}");

            foreach (var book in author.Books)
                Console.WriteLine($"Book: {book.Name} ({book.Genre})");

        }
    }
}
