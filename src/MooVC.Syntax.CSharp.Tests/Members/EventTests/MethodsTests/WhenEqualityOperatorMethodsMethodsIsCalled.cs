namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorMethodsMethodsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Event.Methods? left = default;
        Event.Methods? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Event.Methods? left = default;

        var right = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods? right = default!;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentAddValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentRemoveValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var right = new Event.Methods
        {
            Remove = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}