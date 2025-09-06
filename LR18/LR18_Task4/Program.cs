using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Windows.Forms;

namespace LR18_Task4
{
    class Program
    {
        static bool InputBox(ref int x, string message)
        {
            string s;
            while (true)
            {
                s = Interaction.InputBox(message, "Введення", x.ToString());
                if (string.IsNullOrEmpty(s))
                    return false;
                try
                {
                    x = int.Parse(s);
                    return true;
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Ви ввели не число!\n\nБажаєте повторити?", "Помилка!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return false;
                    }
                }
            }
        }
        static bool IsPrime(int num, int divisor = 2)
        {
            if (num < 2) return false;
            if (divisor * divisor > num) return true;
            if (num % divisor == 0) return false;
            return IsPrime(num, divisor + 1);
        }
        static void FindMersenne(int p, int n, StringBuilder sb)
        {
            int mersenne = (int)Math.Pow(2, p)-1;
            if (mersenne >= n) return;

            if (IsPrime(p) && IsPrime(mersenne))
                sb.AppendLine($"M({p}) = {mersenne}");
            FindMersenne(p+1,n,sb);
        }
        static void Main(string[] args)
        {
            int n = 0;
            bool repeat;
            StringBuilder sb = new StringBuilder();

            do
            {
                if (!InputBox(ref n, "Введіть n"))
                    return;
                sb.Clear();
                sb.AppendLine($"Числа Марсена менші за {n}:");
                FindMersenne(2,n,sb);
                repeat = (MessageBox.Show(sb.ToString() + "Бажаєте повторити?", "Результати обчислень", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes);
            }
            while (repeat);
        }
    }
}
