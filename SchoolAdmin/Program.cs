using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolAdmin.Data;
using SchoolAdmin.Models;

namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext _db = new DataContext();
            void CreatePupil()
            {
                Console.Write("Enter Pupil's username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Pupil's email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Pupil's age: ");
                int age = int.Parse(Console.ReadLine());

                Pupil pupil = new Pupil()
                {
                    Username = username,
                    Email = email,
                    Age = age
                };

                _db.Pupils.Add(pupil);
                _db.SaveChanges();
                Console.WriteLine("Success");
            }

            void CreateClass()
            {
                Console.Write("Enter Class name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Class duration: ");
                int duration = int.Parse(Console.ReadLine());


                Class cls = new Class()
                {
                    ClassName = name,
                    Duration = duration
                };

                _db.Classes.Add(cls);
                _db.SaveChanges();
                Console.WriteLine("Success");
            }

            void AsignPupiltoClass()
            {
                Console.Write("Enter Pupil id: ");
                int pupilId = int.Parse(Console.ReadLine());

                var pupil = _db.Pupils.Find(pupilId);

                if (pupil == null)
                {
                    Console.WriteLine("Pupil not found!");
                }
                else
                {
                    Console.Write("Enter class id: ");
                    int classId = int.Parse(Console.ReadLine());

                    var clss = _db.Classes.Find(pupilId);

                    if (clss == null)
                    {
                        Console.WriteLine("Class not found!");
                    }
                    else
                    {
                        PupilClass pupilClasses = new PupilClass()
                        {
                            ClassId = clss.Id,
                            PupilId = pupil.Id
                        };

                        _db.PupilClases.Add(pupilClasses);
                        _db.SaveChanges();
                        Console.WriteLine("Success");
                    }
                }
            }

            void DeletePupil()
            {
                Console.WriteLine("Please enter the Id of the pupil you want to delete:");

                if (!int.TryParse(Console.ReadLine(), out int pupilIdDelete))
                {
                    Console.WriteLine("Invalid Id!");
                    return;
                }

                var pupilDelete = _db.Pupils.Find(pupilIdDelete);

                if (pupilDelete == null)
                {
                    Console.WriteLine("Pupil with the indicated Id was not found!");
                    return;
                }

                _db.Pupils.Remove(pupilDelete);
                _db.SaveChanges();

                Console.WriteLine("Pupil deleted successfully.");
            }

            void DeleteClass()
            {
                Console.WriteLine("Please enter the Id of the class you want to delete:");

                if (!int.TryParse(Console.ReadLine(), out int classIdDelete))
                {
                    Console.WriteLine("Invalid Id!");
                    return;
                }

                var classDelete = _db.Classes.Find(classIdDelete);

                if (classDelete == null)
                {
                    Console.WriteLine("Class with the indicated Id was not found!");
                    return;
                }

                _db.Classes.Remove(classDelete);
                _db.SaveChanges();

                Console.WriteLine("Class deleted successfully.");
            }
            while (true)
            {
                Console.WriteLine("1. create pupil");
                Console.WriteLine("2. create class");
                Console.WriteLine("3. asign pupil to class");
                Console.WriteLine("4. delete pupil");
                Console.WriteLine("5. delete class");
                Console.WriteLine("6. show class with pupils");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                if (key == "1")
                {
                    CreatePupil();
                }
                else if (key == "2")
                {
                    CreateClass();
                }
                else if (key == "3")
                {
                    AsignPupiltoClass();
                }
                else if (key == "4")
                {
                    DeletePupil();
                }
                else if (key == "5")
                {
                    DeleteClass();
                }
                else if (key == "6")
                {
                    Console.Write("Enter class id: ");
                    int id = int.Parse(Console.ReadLine());

                    var clasN = _db.Classes
                        .Include(e => e.Pupils)
                        .ThenInclude(e => e.Pupil)
                        .FirstOrDefault(e => e.Id == id);

                    if (clasN == null)
                    {
                        Console.WriteLine("Class not found");
                    }
                    else
                    {
                        Console.WriteLine($"course name: {clasN.ClassName}, duration:{clasN.Duration}");

                        foreach (var item in clasN.Pupils)
                        {
                            Console.WriteLine($"CreatedAt: {item.CreatedDate}");

                            Console.WriteLine($"username: {item.Pupil.Username}, email: {item.Pupil.Email}, age: {item.Pupil.Age}");
                        }
                    }
                }
            }
        }
    }
}
