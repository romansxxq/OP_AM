using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void generateArray(double[,] array, int N, int M, double a, double b)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    array[i, j] = a + rnd.NextDouble() * (b - a);
        }
        static void printArray(double[,] array, int N, int M, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"[{array[i, j]:F2}] \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static double calculateProduct(double[,] array, int N, int M)
        {
            double product = 1;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    product *= array[i, j];
            return product;

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double a = 18, b = 80;
            int i, j;
            Console.Write("Введіть кількість рядків: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість стовпців: ");
            int M = int.Parse(Console.ReadLine());
            double[,] array = new double[N, M];
            generateArray(array, N, M, a, b);
            printArray(array, N, M, "Згенерований масив:");

            double product = calculateProduct(array, N, M);
            Console.Write($"Добуток елементів масиву: {product}");

        }

    }
}
