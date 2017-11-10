using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    public class Player
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Xp { get; set; }

        public override string ToString()
        {
            return $"{ID.ToString()} {Name.ToString()} {Xp.ToString()}";
        }
    }

    class Program
    {
        static List<Player> players = new List<Player>()
        {
            new Player { ID = Guid.NewGuid(), Name = "Jamie Higgins", Xp = 100},
            new Player { ID = Guid.NewGuid(), Name = "Joe Bloggs", Xp = 50},
            new Player { ID = Guid.NewGuid(), Name = "James McDaid", Xp = 500},
            new Player { ID = Guid.NewGuid(), Name = "Connor O'Connor", Xp = 200}
        };

        static void Main(string[] args)
        {
            // Return the first occurance of the match or null
            Player found = players.FirstOrDefault(p => p.Name == "Jamie Higgins");
            if (found != null)
                Console.WriteLine($"{found.ToString()}");
            else
                Console.WriteLine("Not found!");

            Console.WriteLine();

            // Return the first occurance of the some records
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Jamie"));
            if (found != null)
                Console.WriteLine($"First found: {found1.ToString()}");
            else
                Console.WriteLine("Not found!");

            Console.WriteLine();

            // Return all those with an XP value over 100
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
                foreach (var item in topPlayers)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            else
                Console.WriteLine("Not found!");

            Console.WriteLine();

            // Produce a scoreboard of Player names and scores
            Console.WriteLine("Top Scores");
            var scorboard = players.OrderByDescending(o => o.Xp)
                                            .Select(scores => new { scores.Name, scores.Xp });

            foreach (var item in scorboard)
            {
                Console.WriteLine($"{item.Name} - {item.Xp}");
            }

            Console.ReadKey();
        }
    }
}
