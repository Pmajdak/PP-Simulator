using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class CreatureTests
{
    [Theory]
    [InlineData(Direction.Up, 0, 1)]
    [InlineData(Direction.Right, 1, 0)]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.Down, 0, -1)]
    public void CreatureShouldMoveCorrectlyOnAssignedMap(Direction direction, int dx, int dy)
    {
        // Arrange
        var startPoint = new Point(2, 2);
        var expectedPoint = new Point(startPoint.X + dx, startPoint.Y + dy);

        var map = new SmallSquareMap(10);
        var creature = new Elf("Elf1");
        creature.AssignMap(map, startPoint);

        // Act
        creature.Go(direction);

        // Assert
        Assert.Equal(expectedPoint, creature.CreaturePos);
    }
}
