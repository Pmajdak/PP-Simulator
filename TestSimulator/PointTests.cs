using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetPropertiesCorrectly()
    {
        var point = new Point(5, 10);

        Assert.Equal(5, point.X);
        Assert.Equal(10, point.Y);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 1, 2)]
    [InlineData(1, 1, Direction.Left, 0, 1)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var point = new Point(x, y);

        var next = point.Next(d);

        Assert.Equal(new Point(expectedX, expectedY), next);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 2, 2)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var point = new Point(x, y);

        var next = point.NextDiagonal(d);

        Assert.Equal(new Point(expectedX, expectedY), next);
    }
}

