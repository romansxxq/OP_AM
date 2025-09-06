using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR18_Task1
{
    internal class Program
    {
        static bool InputDouble(ref double x, string message)
        {
            string s;
            while (true)
            {
                s = Interaction.InputBox(message, "Введення", x.ToString());
                if (string.IsNullOrEmpty(s) )
                    return false;
                try
                {
                    x = Convert.ToDouble(s);
                    return true;
                }
                catch { 
                    DialogResult result = MessageBox.Show("Ви ввели не число!\n\nБажаєте повторити?","Помилка!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
        static double Sqrt(double a, double b, double c, double d) { 
            return Math.Pow(a + Math.Cos(b*c), 1.0 / d);
        }
        static void Main(string[] args)
        {
            double x = 1.5, y = 0.8, z = 0, sum;
            bool repeat;


            do
            {
                if (!InputDouble(ref x, "Введіть x:"))
                return;
                if (!InputDouble(ref y, "Введіть y:"))
                return;
                if (!InputDouble(ref z, "Введіть z:"))
                return;

                sum = Sqrt(2, x,x, 3) / 84.0 
                    + (5.87+x) / Sqrt(3,y,y,5) 
                    + Sqrt(2,x,y,3)/9.0;

                repeat = (MessageBox.Show($"При x={x},y={y} та z = {z} значення виразу рівне {sum}\n\nБажаєте повторити?", "Результати обчислень", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes);
            }
            while (true);
        }
    }
}
