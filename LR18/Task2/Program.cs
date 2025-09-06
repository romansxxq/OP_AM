using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Windows.Forms;

namespace LR18_Task2
{
    class Program
    {
        static bool InputDouble(ref double x, string message)
        {
            string s;
            while (true)
            {
                s = Interaction.InputBox(message, "Введення", x.ToString());
                if (string.IsNullOrEmpty(s))
                    return false;
                try
                {
                    x = Convert.ToDouble(s);
                    return true;
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Ви ввели не число!\n\nБажаєте повторити?", "Помилка!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return false;
                    }
                    //else
                    //{
                    //    return true;
                    //}
                }
            }
        }
        static double AreaHerona(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p-c));
        }
        static void Main(string[] args)
        {
            double a1= 3, b1=4 , c1=5;
            double a2 = 2, b2 = Math.Sqrt(37), c2 = Math.Sqrt(37);

            bool repeat;


            do
            {
                //Triangle1
                if (!InputDouble(ref a1, "Введіть сторону a для першого трикутника:")) return;
                if (!InputDouble(ref b1, "Введіть сторону a для першого трикутника:")) return;
                if (!InputDouble(ref c1, "Введіть сторону a для першого трикутника:")) return;

                //Triangle2
                if (!InputDouble(ref a2, "Введіть сторону a для другого трикутника:")) return;
                if (!InputDouble(ref b2, "Введіть сторону a для другого трикутника:")) return;
                if (!InputDouble(ref c2, "Введіть сторону a для другого трикутника:")) return;

                double triangle1 = AreaHerona(a1, b1, c1);
                double triangle2 = AreaHerona(a2, b2, c2);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Площа першого трикутника = {triangle1}");
                sb.AppendLine($"Площа другого трикутника = {triangle2}");
                //string message = $"Площа першого трикутника = {triangle1}\n" +
                //                 $"Площа другого трикутника = {triangle2}\n\n";

                if (Math.Abs(triangle1 - triangle2) < 1e-9)
                    sb.AppendLine("Трикутники мають однакову площу");
                else if (triangle1 > triangle2)
                    sb.AppendLine("Перший трикутник має більшу площу");
                else  sb.AppendLine("Другий трикутник має більшу площу");
                repeat = (MessageBox.Show(sb.ToString()+"Бажаєте повторити?", "Результати обчислень", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes);
            }
            while (true);
        }
    }
}
