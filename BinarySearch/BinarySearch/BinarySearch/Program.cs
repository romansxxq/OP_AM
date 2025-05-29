using System;

class Program
{
    static void Main()
    {
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
        Console.Write("Індекси входження елемента: ");
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] == target)
            {
                Console.Write(mid + " ");
                int i = mid - 1, j = mid + 1;
                while (i >= 0 && array[i] == target) Console.Write(i-- + " ");
                while (j < N && array[j] == target) Console.Write(j++ + " ");
                return;
            }
            else if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        Console.WriteLine("Елемент не знайдено.");
    }
}