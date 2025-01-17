using Simulator.Maps;
using Simulator;

namespace SimConsole;

internal class Program
{
    static void Main()
    {


        Birds dodo = new() { Description = "dodo", CanFly = false };
        Birds dodo2 = new() { Description = "dodo", CanFly = false };


        BigBounceMap map = new(8, 6);
        BigBounceMap map2 = new(8, 6);


        List<IMappable> creatures = [dodo];
        List<IMappable> creatures2 = [dodo2];

        List<Point> points = [new(4, 4)];
        List<Point> points2 = [new(4, 4)];

        string moves = "rrrrrr";
        Simulation simulation = new(map, creatures, points, moves) { DebugTurn = true };
        Simulation simulation2 = new(map2, creatures2, points2, moves) { DebugTurn = false };

        MapVisualizer mapVisualizer = new(map);

        SimulationHistory history = new(simulation2);

        LogVisualizer logs = new(history);

        int i = 0;
        do
        {
            mapVisualizer.Draw();
            logs.Draw(i);
            simulation.Turn();
            i++;
        } while (!simulation.Finished);
    }
}
