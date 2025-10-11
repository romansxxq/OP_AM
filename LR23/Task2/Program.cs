using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
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

        static void Main()
        {
            string filePath = @"D:\OP_AM-C#\OP_AM\LR23\Task1\bin\Debug\teams.dat";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не знайдено! Створіть його першою програмою.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string input = Interaction.InputBox("How many new teams do you want to add?", "Add Teams", "1");
            if (!int.TryParse(input, out int newTeams) || newTeams <= 0)
            {
                MessageBox.Show("Invalid number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Teams[] teamsToAdd = new Teams[newTeams];
            for (int i = 0; i < newTeams; i++)
            {
                string name = Interaction.InputBox($"Enter the name of new team {i + 1}:", "Team Name", $"TeamNew{i + 1}");
                if (name.Length > NameLength) name = name.Substring(0, NameLength);

                string scoreInput = Interaction.InputBox($"Enter the score for team {name}:", "Team Score", "0");
                if (!int.TryParse(scoreInput, out int score) || score < 0)
                {
                    MessageBox.Show("Invalid score! Enter a non-negative integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    i--; 
                    continue;
                }

                teamsToAdd[i] = new Teams(name, score);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Append)))
            {
                foreach (var team in teamsToAdd)
                {
                    byte[] nameBytes = Encoding.UTF8.GetBytes(team.TeamName.PadRight(NameLength));
                    writer.Write(nameBytes);
                    writer.Write(team.TeamScore);
                }
            }

            Teams[] allTeams;
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int recordSize = NameLength + sizeof(int);
                int count = (int)reader.BaseStream.Length / recordSize;
                allTeams = new Teams[count];

                for (int i = 0; i < count; i++)
                {
                    byte[] nameBytes = reader.ReadBytes(NameLength);
                    string name = Encoding.UTF8.GetString(nameBytes).Trim();
                    int score = reader.ReadInt32();
                    allTeams[i] = new Teams(name, score);
                }
            }

            int maxScore = int.MinValue;
            foreach (var t in allTeams)
                if (t.TeamScore > maxScore) maxScore = t.TeamScore;

            string champions = "Champion(s): ";
            foreach (var t in allTeams)
                if (t.TeamScore == maxScore)
                    champions += t.TeamName + " ";

            MessageBox.Show(champions, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FileInfo fi = new FileInfo(filePath);
            MessageBox.Show($"Current file size: {fi.Length} bytes", "File Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
