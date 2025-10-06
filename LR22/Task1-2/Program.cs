using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    struct Student
    {
        public string Surname;
        public char Gender;
        public int BirthYear;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"Stud.dat";

            if (!File.Exists(path))
            {

                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    Student[] students =
                    {
                    new Student { Surname = "Melnychuk", Gender = 'M', BirthYear = 2005 },
                    new Student { Surname = "Koval", Gender = 'F', BirthYear = 2006 },
                    new Student { Surname = "Ivanov", Gender = 'M', BirthYear = 2004 },
                    new Student { Surname = "Shevchenko", Gender = 'M', BirthYear = 2003 },
                    new Student { Surname = "Petrenko", Gender = 'F', BirthYear = 2005 }
                };
                    foreach (var student in students)
                    {
                        writer.Write(student.Surname);
                        writer.Write(student.Gender);
                        writer.Write(student.BirthYear);
                    }
                }
                Console.WriteLine("File Stud.dat has been created and filled with initial students.\n");
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append), Encoding.UTF8))
            {
                Student[] newStudents =
                {
                new Student { Surname = "Bondarenko", Gender = 'M', BirthYear = 2005 },
                new Student { Surname = "Tkachenko", Gender = 'F', BirthYear = 2006 },
                new Student { Surname = "Kravchenko", Gender = 'M', BirthYear = 2004 }
            };

                foreach (var s in newStudents)
                {
                    writer.Write(s.Surname);
                    writer.Write(s.Gender);
                    writer.Write(s.BirthYear);
                }
            }
            Console.WriteLine("New students have been appended to Stud.dat.\n");

            int currentYear = DateTime.Now.Year;
            int countMan = 0;
            double sumAge = 0;

            Console.WriteLine("Male students list:\n");

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.UTF8))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Student student = new Student();
                    student.Surname = reader.ReadString();
                    student.Gender = reader.ReadChar();
                    student.BirthYear = reader.ReadInt32();

                    if (student.Gender == 'M')
                    {
                        int age = currentYear - student.BirthYear;
                        Console.WriteLine($"Surname: {student.Surname,-15} | {age} y.o");
                        countMan++;
                        sumAge += age;
                    }
                }
            }
            if (countMan > 0)
            {
                double averageAge = sumAge / countMan;
                Console.WriteLine($"\nAverage year male students: {averageAge:F2} y.o");
            }
            else
            {
                Console.WriteLine("No male students found.");
            }
        }
    }
}
