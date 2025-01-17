using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;

namespace SimConsole;

internal class LogVisualizer
{
    SimulationHistory Log { get; }

    public LogVisualizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnNumber)
    {
        DrawHorizontalLine(true);
        for (int j = Log.SizeY; j > 0; j--)
        {
            if (j != Log.SizeY)
            {
                DrawHorizontalLine(false);
            }
            NextLine();
            for (int i = 0; i < Log.SizeX; i++)
            {
                DrawSeparator();
                DrawCreature(CreatureAt(new Point(i, j), turnNumber));
            }
            DrawSeparator();
            NextLine();
        }
        DrawHorizontalLine(false, bottom: true);
    }

    private void DrawHorizontalLine(bool top, bool bottom = false)
    {
        DrawCorner(top ? 1 : bottom ? 3 : 0);
        for (int i = 0; i < Log.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(top ? Box.TopMid : bottom ? Box.BottomMid : Box.Cross);
        }
        Console.Write(Box.Horizontal);
        DrawCorner(top ? 2 : bottom ? 4 : 0);
    }

    private static void DrawCorner(int type)
    {
        Console.Write(type switch
        {
            1 => Box.TopLeft,
            2 => Box.TopRight,
            3 => Box.BottomLeft,
            4 => Box.BottomRight,
            _ => Box.Cross
        });
    }

    private static void DrawSeparator() => Console.Write(Box.Vertical);

    private static void NextLine() => Console.WriteLine();

    private static void DrawCreature(char symbol) => Console.Write(symbol);

    private char CreatureAt(Point point, int turnNumber)
    {
        return Log.TurnLogs[turnNumber].Symbols.TryGetValue(point, out var symbol) ? symbol : ' ';
    }
}
