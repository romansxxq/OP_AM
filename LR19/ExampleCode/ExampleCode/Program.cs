using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitMatviichuk;

namespace ExampleCode
{
    internal class Program
    {
        static void KvadratneRivnyannya()
        {
            int a = correctInput.inputInt("Введіть a: ");
            int b = correctInput.inputInt("Введіть b: ");
            int c = correctInput.inputInt("Введіть c: ");

            double D = b * b - 4 * a * c; // Dyscriminant

            if (D > 0)
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"Два корені: x1 = {x1}, x2 = {x2}");
            }
            else if (D == 0)
            {
                double x = -b / (2.0 * a);
                Console.WriteLine($"Один корінь: x = {x}");
            }
            else // D < 0
            {
                double realPart = -b / (2.0 * a);
                double imaginaryPart = Math.Sqrt(-D) / (2 * a);
                Console.WriteLine($"Комплексні корені: x1 = {realPart} + {imaginaryPart}i, x2 = {realPart} - {imaginaryPart}i");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            KvadratneRivnyannya();

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}