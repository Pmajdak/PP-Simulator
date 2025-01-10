using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Rectangle
{
    public int X1 { get; }
    public int Y1 { get; }
    public int X2 { get; }
    public int Y2 { get; }

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
            throw new ArgumentException("Cannot create a rectangle with collinear points.");

        X1 = Math.Min(x1, x2);
        Y1 = Math.Min(y1, y2);
        X2 = Math.Max(x1, x2);
        Y2 = Math.Max(y1, y2);
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }

    public bool Contains(Point point) =>
        point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2;
}
