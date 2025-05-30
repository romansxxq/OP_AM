using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть розмір масиву N: ");
        int N;
        while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
        {
            Console.WriteLine("Некоректне значення! Введіть додатне ціле число.");
        }

        double[] array = new double[N];
        Console.WriteLine($"Введіть {N} елементів масиву:");
        for (int i = 0; i < N; i++)
        {
            while (!double.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Некоректне значення! Введіть дійсне число.");
            }
        }

        Array.Sort(array);


        Console.Write("Введіть елемент для пошуку: ");
        double target;
        while (!double.TryParse(Console.ReadLine(), out target))
        {
            Console.WriteLine("Некоректне значення! Введіть дійсне число.");
        }

        int left = 0, right = N - 1;
        bool found = false;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] == target)
            {
                int i = mid;
                while (i >= 0 && array[i] == target) i--;
                i++;
                int j = mid;
                while (j < N && array[j] == target) j++;j--;
                found = true;
                if (i == j)
                {
                    Console.WriteLine("Елемент знайдено один раз: " + i);
                }
                else
                {
                    Console.WriteLine("Елемент знайдено декілька разів:");
                }
                for (int k = i; k < j; k++)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();
                break;
            }
            else if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        if (!found)
        {
            Console.WriteLine("Елемент не знайдено.");
        }

    }
}