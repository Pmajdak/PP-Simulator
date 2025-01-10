namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private const int MaxSize = 20;
    private readonly List<Creature>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > MaxSize || sizeY > MaxSize)
        {
            throw new ArgumentOutOfRangeException("Blad! - Maksymalny rozmiar mapy to 20 punktow.");
        }
        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point point)
    {
        ValidatePoint(point);

        _fields[point.X, point.Y] ??= new List<Creature>();
        _fields[point.X, point.Y]!.Add(creature);
    }

    public override void Remove(Creature creature, Point point)
    {
        _fields[point.X, point.Y]?.Remove(creature);
    }

    public override List<Creature> At(Point point)
    {
        return _fields[point.X, point.Y] ?? new List<Creature>();
    }

    public override List<Creature> At(int x, int y) => At(new Point(x, y));

    private void ValidatePoint(Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException("Blad! - Wskazany punkt nie nalezy do mapy.");
        }
    }
}
