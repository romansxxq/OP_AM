using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Windows.Forms;

namespace Task2
{
    internal class Task2
    {
        static int InputInt(string message)
        {
            while (true)
            {
                string input = Interaction.InputBox(message, "Ввід");
                if (string.IsNullOrEmpty(input))
                    Environment.Exit(0);
                if (int.TryParse(input, out int num) && num > 0)
                    return num;
                MessageBox.Show("Введіть додатне ціле число!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        static float[,] GenerateArray(int M, int N)
        {
            Random rnd = new Random();
            float[,] array = new float[M, N];
            float min = -40, max = 60;

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    array[i, j] = (float)(min + rnd.NextDouble() * (max - min));

            return array;
        }

        static int CountNegNums(float[,] array, int rowIndex, int columns)
        {
            int count = 0;
            for (int j = 0; j < columns; j++)
                if (array[rowIndex, j] < 0)
                    count++;
            return count;
        }

        static void PrintResult(float[,] array, int[] negatives, int M, int N)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Згенерована матриця:");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    sb.Append($"{array[i, j],8:F2} ");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.AppendLine("Кількість від'ємних елементів у кожному рядку:");
            for (int i = 0; i < M; i++)
                sb.AppendLine($"Рядок {i + 1}: {negatives[i]}");

            MessageBox.Show(sb.ToString(), "Результат");
        }

        static void Main(string[] args)
        {
            int M = InputInt("Введіть кількість рядків:");
            int N = InputInt("Введіть кількість стовпців:");

            float[,] originalArray = GenerateArray(M, N);
            int[] negativeArray = new int[M];

            for (int i = 0; i < M; i++)
                negativeArray[i] = CountNegNums(originalArray, i, N);

            PrintResult(originalArray, negativeArray, M, N);
        }
    }
}
