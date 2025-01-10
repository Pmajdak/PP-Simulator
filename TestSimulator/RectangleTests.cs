using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldCreateRectangle()
    {
        var rectangle = new Rectangle(0, 0, 5, 5);

        Assert.Equal(0, rectangle.X1);
        Assert.Equal(0, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(5, rectangle.Y2);
    }

    [Fact]
    public void Constructor_CollinearPoints_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
    }

    [Theory]
    [InlineData(2, 2, true)]
    [InlineData(6, 6, false)]
    public void Contains_ShouldReturnCorrectValue(int x, int y, bool expected)
    {
        var rectangle = new Rectangle(0, 0, 5, 5);
        var point = new Point(x, y);

        var result = rectangle.Contains(point);

        Assert.Equal(expected, result);
    }
}
