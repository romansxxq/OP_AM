using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    struct Teams
    {
        public string TeamName;
        public int TeamScore;
        public Teams(string name, int score)
        {
            TeamName = name;
            TeamScore = score;
        }
    }
    internal class Program
    {
        const int NameLength = 20;
        static void Main(string[] args)
        {
            string input = Interaction.InputBox("Enter the number of teams:", "Number of Teams", "3");
            if (!int.TryParse(input, out int numberOfTeams) || numberOfTeams <= 0)
            {
                MessageBox.Show("Invalid number of teams.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Teams[] teams = new Teams[numberOfTeams];
            for (int i = 0; i < numberOfTeams; i++)
            {
                string name = Interaction.InputBox($"Enter the name of team {i + 1}:", "Team Name", $"Team{i + 1}");
                if (name.Length > NameLength) name = name.Substring(0, NameLength);
                string scoreInput = Interaction.InputBox($"Enter the score for team {name}:", "Team Score", "0");
                if (!int.TryParse(scoreInput, out int score) || score < 0)
                {
                    MessageBox.Show("Invalid score! Enter a non-negative integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    i--;
                    continue;
                }
                teams[i] = new Teams(name, score);
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "teams.dat");
            using (BinaryWriter writer = new BinaryWriter(File.Open("teams.dat", FileMode.Create)))
            {
                foreach (var team in teams)
                {
                    byte[] nameBytes = Encoding.UTF8.GetBytes(team.TeamName.PadRight(NameLength));
                    writer.Write(nameBytes);
                    writer.Write(team.TeamScore);
                }
            }

            MessageBox.Show($"Teams have been written to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
