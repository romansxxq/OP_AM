using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    struct Team { 
        public string Name;
        public int Score;

        public Team (string name, int score)
        {
            Name = name;
            Score = score;
        }
        public void DisplayInfo() {
            Console.WriteLine($"Team: {Name}, Score: {Score}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            Console.WriteLine("Enter team (empty name = stop): ");
            int i = 1;
            while (true)
            {
                Console.WriteLine($"\nTeam {i}:");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                    break;
                Console.Write("Enter score: ");
                int score = int.Parse(Console.ReadLine());

                teams.Add(new Team(name, score));
                i++;
            }
            Console.WriteLine("List of teams: ");
            foreach (var team in teams)
                team.DisplayInfo();
            Console.WriteLine("\nEnter minimum score to filter teams: ");
            int minScore = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nTeams with more than {minScore} points:");
            foreach (var team in teams.Where(t => t.Score > minScore))
                team.DisplayInfo();


        }
    }
}
