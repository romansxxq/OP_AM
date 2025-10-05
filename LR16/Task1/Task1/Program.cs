using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitMatviichuk;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введил любий текст: ");
            string message = Console.ReadLine();
            string result = analizText.rozdilZnak(message);
            //string result = "";
            //foreach (char ch in message)
            //{
            //    result += ch + "?";
            //}
            Console.WriteLine("Результат: "+result);
        }
    }
}
