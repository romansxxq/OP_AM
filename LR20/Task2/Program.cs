using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] writers = new string[5];
            string filePath = @"D:\OP_AM-C#\OP_AM\LR20\Matviichuk.txt";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            writers = File.ReadAllLines(filePath);
            string result = "";
            foreach (string writer in writers)
            {
                result += writer + "\n";
            }
            MessageBox.Show(result, "Writers", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
