namespace MooVC.Linq.PagingTests;

public sealed class WhenEqualityIsChecked
{
    [Fact]
    public void GivenTwoIdenticalInstancesThenEqualityIsConfirmed()
    {
        // Arrange
        var first = new Paging(1, 10);
        var second = new Paging(1, 10);

        // Act
        bool areEqual = first.Equals(second);
        bool operatorEqual = first == second;
        bool operatorNotEqual = first != second;

        // Assert
        _ = areEqual.Should().BeTrue();
        _ = operatorEqual.Should().BeTrue();
        _ = operatorNotEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentInstancesThenInequalityIsConfirmed()
    {
        // Arrange
        var first = new Paging(1, 10);
        var second = new Paging(2, 10);

        // Act
        bool areEqual = first.Equals(second);
        bool operatorEqual = first == second;
        bool operatorNotEqual = first != second;

        // Assert
        _ = areEqual.Should().BeFalse();
        _ = operatorEqual.Should().BeFalse();
        _ = operatorNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenAnInstanceAndNullThenInequalityIsConfirmed()
    {
        // Arrange
        var first = new Paging(1, 10);
        Paging? second = null;

        // Act
        bool areEqual = first.Equals(second);
        bool operatorEqual = first == second;
        bool operatorNotEqual = first != second;

        // Assert
        _ = areEqual.Should().BeFalse();
        _ = operatorEqual.Should().BeFalse();
        _ = operatorNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenTwoInstancesReferringToTheSameObjectThenEqualityIsConfirmed()
    {
        // Arrange
        var first = new Paging(1, 10);
        Paging second = first;

        // Act
        bool areEqual = first.Equals(second);
        bool operatorEqual = first == second;
        bool operatorNotEqual = first != second;

        // Assert
        _ = areEqual.Should().BeTrue();
        _ = operatorEqual.Should().BeTrue();
        _ = operatorNotEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoInstancesWithDifferentSizesThenInequalityIsConfirmed()
    {
        // Arrange
        var first = new Paging(1, 10);
        var second = new Paging(1, 20);

        // Act
        bool areEqual = first.Equals(second);
        bool operatorEqual = first == second;
        bool operatorNotEqual = first != second;

        // Assert
        _ = areEqual.Should().BeFalse();
        _ = operatorEqual.Should().BeFalse();
        _ = operatorNotEqual.Should().BeTrue();
    }
}