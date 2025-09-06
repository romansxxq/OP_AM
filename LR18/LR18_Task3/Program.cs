using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Windows.Forms;

namespace LR18_Task3
{
    class Program
    {
        static bool InputBox(ref int x, string message, int min, int max)
        {
            string s;
            while (true)
            {
                s = Interaction.InputBox(message, "Введення", x.ToString());
                if (string.IsNullOrEmpty(s))
                    return false;
                try
                {
                    if (x < min || x > max)
                    {
                        MessageBox.Show($"Число має бути від {min} до {max}!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
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
        //static int AckermannFunction(int m, int n)
        //{
        //    while (m != 0) { 
        //        if (m == 0)
        //            m = 1;
        //        else m = AckermannFunction(n, m - 1);
        //        n = n - 1;
        //    }
        //    return m + 1;
        //}
        static int AckermannFunction(int m, int n)
        {
            if (m == 0)
                return n + 1;
            else if (m > 0 && n == 0)
                return AckermannFunction(m - 1, 1);
            else return AckermannFunction(m - 1, AckermannFunction(m, n - 1));
        }
        static void Main(string[] args)
        {
            int m =0, n = 0;
            bool repeat;
            StringBuilder sb = new StringBuilder();

            do
            {
                if (!InputBox(ref m, "Введіть m", 0,3) || !InputBox(ref n, "Введіть n",0,10))
                    return;
                sb.Clear();
                int result = AckermannFunction(m, n);
                sb.AppendLine($"A({m},{n}) = {result}");
                repeat = (MessageBox.Show(sb.ToString()+"Бажаєте повторити?", "Результати обчислень", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes);
            }
            while (repeat);
        }
    }
}
