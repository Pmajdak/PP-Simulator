using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        private int CurrentTurn { get; set; } = 0;
        public bool DebugTurn {  get; set; } = true;
        private Direction[] Directions {  get; set; }
        public Map Map { get; init; }
        public List<IMappable> Creatures { get; init; }

        public List<Point> Positions { get; init; }

        public string Moves { get; init; }

        public bool Finished = false;

        public IMappable CurrentCreature { get; set; }

        public string CurrentMoveName { get; set; } 

        public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
        {
            if (creatures is null || creatures.Count == 0 || creatures.Count != positions.Count)
            {
                throw new Exception("error simulation");
            }
            else
            {

                Map = map;
                Creatures = creatures;
                Positions = positions;
                Moves = moves;
                CurrentCreature = Creatures.First();
                Directions = DirectionParser.Parse(moves);
                CurrentMoveName = moves[0].ToString();

                AddCreaturesToMap();
            }   
        }
        private void AddCreaturesToMap()
        {
            for(int i = 0; i < Creatures.Count; i++)
            {
                Creatures[i].SetMap(Map, Positions[i]);
            }
        }

        private IMappable NextCreature()
        {
            if (CurrentTurn < (Creatures.Count-1))
            {
                return Creatures[CurrentTurn];
            }
            else
            {
                return Creatures[(CurrentTurn) % Creatures.Count];
            }
        }
        private string NextMoveName()
        {
            return Moves[CurrentTurn].ToString();
        }

        public Dictionary<Point, char> SymbolsOnPoint()
        {
            Dictionary<Point, char> dict = new();

            foreach (IMappable c in Creatures)
            {
                dict.Add(c.Location, c.Symbol);
            }
            return dict;
        }

        public void Turn()
        {
            CurrentCreature.Go(Directions[CurrentTurn]);
            
            CurrentTurn++;

            if (CurrentTurn < Directions.Length)
            {
                CurrentCreature = NextCreature();
                CurrentMoveName = NextMoveName();

            }
            else
                Finished = true;
            if (DebugTurn)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
            }
        }
    }
}
