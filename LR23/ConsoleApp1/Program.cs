using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long b = 0;
            bool debt = false;
            for (int i  = 0; i < n; i++)
            {
                string[] p = Console.ReadLine().Split(' ');
                string ac = p[0];
                long am = long.Parse(p[1]);

                if (ac == "earn") b += am;
                else if (ac == "spend") b -= am;

                if (b < 0) debt = true;
            }

            if (debt) Console.WriteLine("debt");
            else Console.WriteLine("chinazes");
        }
    }
}
