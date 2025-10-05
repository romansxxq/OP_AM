using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    struct Student
    {
        public string Surname;
        public string Gender;
        public int Age;

        public Student(bool fromUser)
        {
            Console.Write("Enter surname: ");
            Surname = Console.ReadLine();
            while (true)
            {
                Console.Write("Enter Gnder (M/F): ");
                Gender = Console.ReadLine().ToUpper();
                if (Gender == "M" || Gender == "F") break;
                Console.WriteLine("Incorrect! Try again");
            }
            while (true)
            {
                Console.Write("Enter age: ");
                if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                {
                    Age = age;
                    break;
                }
                Console.WriteLine("Invalid date! Try again.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nStudent #{i + 1}:");
                students[i] = new Student(true);
            }

            string path = @"D:\OP_AM-C#\OP_AM\LR21\students.txt";
            //int n=20;
            //Student[] students = new Student[n];
            //Random rnd = new Random();
            //string[] surnames = { "Ivanov", "Petrov", "Sidorov", "Kovalenko", "Shevchenko",
            //                      "Bondarenko", "Tkachenko", "Melnyk", "Kravets", "Boyko",
            //                      "Fedorov", "Moroz", "Pavlenko", "Hrytsenko", "Lysenko",
            //                      "Savchenko", "Kozak", "Chernenko", "Vasyliev", "Dudko" };

            //for (int i = 0; i < students.Length; i++)
            //{
            //    students[i].Surname = surnames[i];
            //    students[i].Gender = rnd.Next(0, 2) == 0 ? "M" : "F";
            //    students[i].Age = rnd.Next(17, 31);
            //}
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < n; i++)
                {
                    sw.WriteLine($"{students[i].Surname};{students[i].Gender};{students[i].Age}");
                }
            }
            Console.WriteLine($"\nFile `{path}` created sucessfully!");

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found!");
                return;
            }

            List<Student> maleStudents = new List<Student>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length != 3) continue;

                    string surname = parts[0];
                    string gender = parts[1];
                    if (!int.TryParse(parts[2], out int age)) continue;

                    if (gender == "M")
                    {
                        maleStudents.Add(new Student
                        {
                            Surname = surname,
                            Gender = gender,
                            Age = age
                        });
                    }
                }
            }
            Console.WriteLine("\nMale students:");
            int totalAge = 0;
            foreach (var student in maleStudents)
            {
                totalAge += student.Age;
                Console.WriteLine($"{student.Surname}\n Age: {student.Age} y.o");
            }

            if (maleStudents.Count > 0)
            {
                double averageAge = (double)totalAge / maleStudents.Count;
                Console.WriteLine($"\nAverage age of male students: {averageAge:F2}");
            }
            else
            {
                Console.WriteLine("Male students not found.");
            }
        }
    }
}
