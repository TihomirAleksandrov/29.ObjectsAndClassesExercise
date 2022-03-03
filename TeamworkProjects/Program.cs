using System;
using System.Linq;
using System.Collections.Generic;

namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int teamsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < teamsNum; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string teamName = teamInfo[1];
                string creatorName = teamInfo[0];

                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team team = new Team(teamName, creatorName);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] teamChanges = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string userName = teamChanges[0];
                string teamName = teamChanges[1];

                Team selectedTeam = teams.FirstOrDefault(x => x.Name == teamName);

                if (selectedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Members.Contains(userName)))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(x => x.Creator == userName))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                    continue;
                }

                selectedTeam.AddMembers(userName);
            }

            List<Team> fullTeams = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();
            List<Team> emptyTeams = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (Team team in fullTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                foreach (string member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in emptyTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    } 
    
    public class Team
    {
        public Team(string teamName, string creatorName)
        {
            Name = teamName;
            Creator = creatorName;

            Members = new List<string>();
        }
        
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public void AddMembers(string member)
        {
            Members.Add(member);
        }
    }
}
