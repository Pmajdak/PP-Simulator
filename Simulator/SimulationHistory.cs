using Simulator.Maps;

namespace Simulator;
public class SimulationHistory
{
    private readonly Simulation _simulation;
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        var startingPosDict = _simulation.Creatures
            .Select((creature, i) => new { Point = _simulation.Positions[i], Symbol = creature.Symbol })
            .ToDictionary(x => x.Point, x => x.Symbol);

        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "Pozycje startowe",
            Move = "Pozycje startowe",
            Symbols = startingPosDict
        });

        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            var symbolsPos = new Dictionary<Point, char>();

            _simulation.Turn();

            for (int row = 0; row < SizeY; row++)
            {
                for (int col = 0; col < SizeX; col++)
                {
                    var mapCell = _simulation.Map.At(col, row);
                    symbolsPos[new Point(col, row)] = mapCell.Count switch
                    {
                        > 1 => 'X',
                        1 => mapCell[0].Symbol,
                        _ => symbolsPos.GetValueOrDefault(new Point(col, row), default)
                    };
                }
            }

            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentCreature.ToString(),
                Move = _simulation.CurrentMoveName,
                Symbols = symbolsPos
            });
        }
    }
}