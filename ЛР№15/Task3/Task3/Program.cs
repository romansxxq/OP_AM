
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int N = 10;
            int minCoord = -100; int maxCoord = 100;
            double[,] matrix = new double[2, N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                matrix[0, i] = rnd.Next(minCoord, maxCoord + 1);
                matrix[1, i] = rnd.Next(minCoord, maxCoord + 1);
            }

            Console.WriteLine("Згенеровані точки:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{matrix[i, j],6:F0}");
                }
                Console.WriteLine();
            }

            double maxD = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++) { 
                    double dx = matrix[0, i] - matrix[0, j]; 
                    double dy = matrix[1, i] - matrix[1, j];  
                    double d = Math.Sqrt(dx * dx + dy * dy);

                    if (d > maxD)
                        maxD = d;
                }
            }
            Console.WriteLine($"Максимальна довжина відрізка: {maxD}");
        }
    }
}