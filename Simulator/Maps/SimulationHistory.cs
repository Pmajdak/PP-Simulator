using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        if (_simulation.DebugTurn == true)
        {
            throw new ArgumentException("Simulation debug mode cannot be set to true");
        }

        List<Map> maps = new List<Map>();
        do
        {
            TurnLogs.Add(new SimulationTurnLog() { Mappable = _simulation.CurrentCreature.ToString(), Move = _simulation.CurrentMoveName, Symbols = _simulation.SymbolsOnPoint() });
            _simulation.Turn();
        } while (!_simulation.Finished);
    }
}

public class SimulationTurnLog
{
    public required string Mappable { get; init; }
    public required string Move { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }

    public override string ToString()
    {
        return $"{Mappable} {Move} {Symbols.First().Value}";
    }
}
