namespace Simulator;

using Simulator.Maps;



internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5b();
    }
    public static void Lab5b()
    {
        try
        {
            Map map1 = new SmallSquareMap(6);
        }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }
        try
        {
            Map map2 = new SmallSquareMap(10);
        }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }
        Map map = new SmallSquareMap(5);
        Point point1 = new Point(2, 6);
        Point point2 = new Point(1, 7);
        Console.WriteLine(map.Exist(point1));
        Console.WriteLine(map.Exist(point2));

        Console.WriteLine(map.Next(point2, Direction.Left));
        Console.WriteLine(map.NextDiagonal(point2, Direction.Left));
    }
}
