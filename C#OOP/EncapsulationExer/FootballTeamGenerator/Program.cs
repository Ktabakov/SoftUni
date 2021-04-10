using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] parts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string cmd = parts[0];

                try
                {
                    if (cmd == "Add")
                    {
                        string teamName = parts[1];

                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = parts[2];
                        int endurance = int.Parse(parts[3]);
                        int spring = int.Parse(parts[4]);
                        int dribble = int.Parse(parts[5]);
                        int passing = int.Parse(parts[6]);
                        int shooting = int.Parse(parts[7]);

                        Player player = new Player(playerName, endurance, spring, dribble, passing, shooting);

                        Team team = teamsByName[teamName];
                        team.AddPlayer(player);
                    }
                    else if (cmd == "Remove")
                    {
                        string teamName = parts[1];
                        string playerName = parts[2];

                        teamsByName[teamName].RemovePlayer(playerName);
                    }
                    else if (cmd == "Rating")
                    {
                        string teamName = parts[1];
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{teamName} - {teamsByName[teamName].AverageRaiting}");
                        }
                    }
                    else if (cmd == "Team")
                    {
                        string teamName = parts[1];
                        Team team = new Team(teamName);

                        teamsByName.Add(teamName, team);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
