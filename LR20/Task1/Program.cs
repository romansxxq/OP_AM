using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] writers = new string[5];
            for (int i = 0; i < writers.Length; i++)
            {
                string input;
                do
                {
                    input = Interaction.InputBox($"Enter the name of writer {i + 1}:", "Writer Input", "");
                    if (input == "exit")
                        return;

                }
                while (string.IsNullOrWhiteSpace(input));
                writers[i] = input;
            }
            //Створення папки
            string folderPath = @"D:\OP_AM-C#\OP_AM\LR20";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //Створення файлу та запис у нього
            string fileName = Path.Combine(folderPath, "Matviichuk.txt");
            File.WriteAllLines(fileName, writers);
            MessageBox.Show($"Writers' names have been saved to {fileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //Копіювання файлу
            string testPath = @"E:\Matviichuk.txt";
            File.Copy(fileName, testPath, true);
            MessageBox.Show($"File copied to {testPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!Directory.Exists(testPath)) 
                Directory.CreateDirectory(testPath);

        }

    }
}
