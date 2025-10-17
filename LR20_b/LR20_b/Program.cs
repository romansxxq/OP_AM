using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR20_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                ShowMenu();
                Console.Write("Enter your choice (0-9): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a number between 0 and 9.");
                    Console.ResetColor();
                    choice = -1;
                    Pause();
                    continue;
                }
                Console.Clear();

                switch (choice)
                {
                    case 1: CheckFileExists(); break;
                    case 2: ReadFileContents(); break;
                    case 3: WriteFileContents(); break;
                    case 4: AppendToFile(); break;
                    case 5: DeleteFile(); break;
                    case 6: CheckDirectoryExists(); break;
                    case 7: CreateDirectory(); break;
                    case 8: ListDirectoryContents(); break;
                    case 9: DeleteDirectory(); break;
                    case 0: Console.WriteLine("Exiting the program. Goodbye!"); Thread.Sleep(1500); break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 9.");
                        Console.ResetColor();
                        break;
                }
                if (choice != 0) Pause();
            }
            while (choice != 0);
        }
        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- File and Directory Operations Menu ---");
            Console.WriteLine("1. Check if a file exists");
            Console.WriteLine("2. Read the contents of a file");
            Console.WriteLine("3. Create/overwrite a file");
            Console.WriteLine("4. Append text to a file");
            Console.WriteLine("5. Delete a file");
            Console.WriteLine("6. Check if a directory exists");
            Console.WriteLine("7. Create a directory");
            Console.WriteLine("8. List the contents of a directory");
            Console.WriteLine("9. Delete a directory (with all its content)");
            Console.WriteLine("10. Move a file on another path");
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("------------------------------------------");
            Console.ResetColor();
        }
        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        static void CheckFileExists()
        {
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The file exists.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file does not exist.");
            }
            Console.ResetColor();
        }
        static void ReadFileContents()
        {
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();
            try
            {
                string content = File.ReadAllText(filePath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File Contents:\n");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            Console.ResetColor();
        }
        static void WriteFileContents()
        {
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter the text to write to the file (end with an empty line):");
            StringBuilder content = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != string.Empty)
            {
                content.AppendLine(line);
            }
            try
            {
                File.WriteAllText(filePath, content.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
        static void AppendToFile()
        {
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter the text to append to the file (end with an empty line):");
            StringBuilder content = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != string.Empty)
            {
                content.AppendLine(line);
            }
            try
            {
                File.AppendAllText(filePath, content.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Text appended successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }
        static void DeleteFile()
        {
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File deleted successfully.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
        static void CheckDirectoryExists()
        {
            Console.Write("Enter the directory path: ");
            string dirPath = Console.ReadLine();
            if (Directory.Exists(dirPath))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The directory exists.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The directory does not exist.");
            }
            Console.ResetColor();
        }
        static void CreateDirectory()
        {
            Console.Write("Enter the directory path to create: ");
            string dirPath = Console.ReadLine();
            try
            {
                Directory.CreateDirectory(dirPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Directory created successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
            Console.ResetColor();
        }
        static void ListDirectoryContents()
        {
            Console.Write("Enter the directory path: ");
            string dirPath = Console.ReadLine();
            if (Directory.Exists(dirPath))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Directory Contents:\n");
                string[] dirs = Directory.GetFiles(dirPath);
                if (!dirs.Any()) Console.WriteLine("No files found.");
                foreach (var dir in dirs)
                {
                    Console.WriteLine(Path.GetFileName(dir));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The directory does not exist.");
            }
        }
        static void DeleteDirectory()
        {
            Console.Write("Enter the directory path to delete: ");
            string dirPath = Console.ReadLine();
            if (Directory.Exists(dirPath))
            {
                Console.Write("WARNING! This will delete the directory and ALL its content. Are you sure? (y/n): ");
                string confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y")
                {
                    try
                    {
                        Directory.Delete(dirPath, true);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Directory deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error deleting directory: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Directory deletion canceled.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The directory does not exist.");
            }
        }
        static void MoveFile()
        {
            Console.Write("Enter the source file path: ");
            string sourcePath = Console.ReadLine();
            Console.Write("Enter the destination file path: ");
            string destPath = Console.ReadLine();
            try
            {
                File.Move(sourcePath, destPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File moved successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error moving file: {ex.Message}");
            }
            Console.ResetColor();
        }
    }
}
