namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Event.Methods? left = default;
        Event.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Event.Methods? left = default;

        var right = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        Event.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentAddValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentRemoveValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}