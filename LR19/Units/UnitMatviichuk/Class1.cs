using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitMatviichuk
{
    public static class analizText
    {
        public static string rozdilZnak(string text)
        {
            string result = "";
            foreach (char c in text)
            {
                if (char.IsPunctuation(c))
                    result += $" [{c}] ";
                else result += c;
            }
            return result;
        }
    }

    public static class correctInput
    {
        public static int inputInt(string message)
        {
            int result;
            string text;
            Console.Write(message);
            text = Console.ReadLine();

            while (!int.TryParse(text, out result))
            {
                Console.Write("Введено не число. Повторите ввод: ");
                text = Console.ReadLine();
            }
            return result;
        }
        public static double inputDouble(string message)
        {
            double result;
            string text;
            Console.Write(message);
            text = Console.ReadLine();

            while (!double.TryParse(text, out result))
            {
                Console.WriteLine("Введено не число. Повторите ввод: ");
                text = Console.ReadLine();
            }
            return result;
        }
    }
}
