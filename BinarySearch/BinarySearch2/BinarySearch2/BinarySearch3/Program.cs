using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch3
{
    internal class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int N;
            do
            {
                Console.Write("Введіть розмірність масиву (ціле додатнє число): ");
            }
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0);

            double[] arr = new double[N];

            for (int i = 0; i < N; i++)
            {
                double element;
                do
                {
                    Console.Write($"Введіть елемент масиву arr[{i}]: ");
                }
                while (!double.TryParse(Console.ReadLine(), out element));
                arr[i] = element;
            }

            double target;
            do
            {
                Console.Write("Введіть елемент для пошуку (дійсне число): ");
            }
            while (!double.TryParse(Console.ReadLine(), out target));

            Array.Sort(arr);
            Console.WriteLine("Масив відсортовано.");

            int firstIndex = FindFirstOccurrence(arr, target);

            if (firstIndex == -1)
            {
                Console.WriteLine($"Елемент {target} не знайдено у масиві");
            }
            else
            {
                int count = CountOccurrences(arr, target, firstIndex);
                Console.WriteLine($"Елемент {target} знайдено вперше на позиції {firstIndex}. Загальна кількість входжень: {count}");
            }
        }

        static int FindFirstOccurrence(double[] arr, double target)
        {
            int left = 0;
            int right = arr.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                    result = mid;
                    right = mid - 1; 
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }
        static int CountOccurrences(double[] arr, double target, int startIndex)
        {
            int count = 0;
            for (int i = startIndex; i < arr.Length && arr[i] == target; i++)
            {
                count++;
            }
            return count;
        }
    }
}
