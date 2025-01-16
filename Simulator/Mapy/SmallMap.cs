namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private const int MaxSize = 20;
    private readonly List<IMappable>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > MaxSize || sizeY > MaxSize)
        {
            throw new ArgumentOutOfRangeException("Blad! - Maksymalny rozmiar mapy to 20 punktow.");
        }
        _fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable inter, Point point)
    {
        ValidatePoint(point);

        _fields[point.X, point.Y] ??= new List<IMappable>();
        _fields[point.X, point.Y]!.Add(inter);
    }

    public override void Remove(IMappable inter, Point point)
    {
        _fields[point.X, point.Y]?.Remove(inter);
    }

    public override List<IMappable> At(Point point)
    {
        return _fields[point.X, point.Y] ?? new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y) => At(new Point(x, y));

    private void ValidatePoint(Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException("Blad! - Wskazany punkt nie nalezy do mapy.");
        }
    }
}
