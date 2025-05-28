using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetupConsoleEncoding();

            while (true)
            {
                string input = InputText("Введіть текст:");
                if (string.IsNullOrWhiteSpace(input))
                {
                    var retry = ShowWarning("Ви не ввели текст!\nХочете спробувати ще раз?");
                    if (retry == DialogResult.OK)
                        continue;
                    else
                        break;
                }
                int wordCount = CountWords(input);

                var again = ShowResult($"Кількість слів: {wordCount}");
                if (again == DialogResult.Cancel)
                    break;
            }
        }

        static void SetupConsoleEncoding()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }

        static string InputText(string message)
        {
            return Interaction.InputBox(message, "Ввід тексту:");
        }

        static DialogResult ShowWarning(string message)
        {
            return MessageBox.Show(message, "Помилка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        static DialogResult ShowResult(string message)
        {
            return MessageBox.Show($"{message}\nХочете спробувати ще раз?", "Результат", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        static int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Текст не повинен бути порожнім.");
            char[] separators = { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}