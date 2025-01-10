using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
internal class SmallSquareMap : Map
{
    public int Size { get; }
    private readonly Rectangle _map;
    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Blad! - Poprawny rozmiar mapy jest od 5 do 20 punktow!");
        }
        Size = size;
        _map = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p)
    {
        return _map.Contains(p);
    }
    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        return Exist(next) ? next : p;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var next = p.NextDiagonal(d);
        return Exist(next) ? next : p;
    }
}