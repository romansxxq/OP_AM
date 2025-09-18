using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    struct ExportGoods
    {
        public string Name;
        public string Country;
        public int Quantity;

        public ExportGoods(string name, string country, int quantity)
        {
            Name = name;
            Country = country;
            Quantity = quantity;
        }
        public void DisplayInfo() {
            Console.WriteLine($"Name: {Name}, Country: {Country}, Quantity: {Quantity}");
        }
        public ExportGoods(bool fromUser) { 
            if (fromUser) {
                Console.Write("Enter name: ");
                Name = Console.ReadLine();
                Console.Write("Enter country: ");
                Country = Console.ReadLine();
                Console.Write("Enter quantity: ");
                Quantity = int.Parse(Console.ReadLine());
            } else {
                Name = "None";
                Country = "None";
                Quantity = 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ExportGoods[] goods = new ExportGoods[5]
            {
                new ExportGoods("Apples", "USA", 100),
                new ExportGoods("Bananas", "Ecuador", 200),
                new ExportGoods("Cherries", "Turkey", 150),
                new ExportGoods("Dates", "Iran", 80),
                new ExportGoods("Elderberries", "UK", 50)
            };

            Console.WriteLine("All export data:");
            foreach (var item in goods)
                item.DisplayInfo();
            while (true)
            {
                Console.Write("\nEnter product name to search: ");
                string productName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(productName))
                    break;
                Console.WriteLine($"\nCountries importing {productName}:");
                bool found = false;
                foreach (var item in goods)
                {
                    if (item.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(item.Country);
                        found = true;
                    }
                }
                if (!found)
                    Console.WriteLine("No data found for the specified product.");
            }
        }
    }
}
