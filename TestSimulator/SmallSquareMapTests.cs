using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetSize(int size)
    {
        var map = new SmallSquareMap(size);

        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(1, 1, 10, true)]
    [InlineData(-1, 0, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);

        var result = map.Exist(point);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 1, 2)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        var result = map.Next(point, d);

        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 2, 2)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        var result = map.NextDiagonal(point, d);

        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}

