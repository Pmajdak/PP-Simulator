using Simulator.Maps;
using Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    private int moveIndex = 0;

    public Creature CurrentCreature => Creatures[moveIndex % Creatures.Count];
    public string CurrentMoveName
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Blad! - Symulacja sie zakonczyla.");
            return DirectionParser.Parse(Moves[moveIndex % Moves.Length].ToString())[0].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (!creatures.Any())
            throw new ArgumentException("Blad! - Lista stworow nie moze byc pusta.");

        if (creatures.Count != positions.Count)
            throw new ArgumentException("Blad! - Lista pozycji startowych musi byc rowna liscie stworow.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].AssignMap(map, positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished) throw new InvalidOperationException("Blad! - Symulacja sie zakonczyla.");

        CurrentCreature.Go(DirectionParser.Parse(Moves)[moveIndex % Moves.Length]);

        if (++moveIndex >= Moves.Length * Creatures.Count)
            Finished = true;
    }
}
