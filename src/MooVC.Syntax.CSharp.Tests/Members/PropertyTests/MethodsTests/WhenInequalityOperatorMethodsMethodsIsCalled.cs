namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Methods? left = default!;
        Property.Methods? right = default!;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Property.Methods? left = default!;
        var right = new Property.Methods
        {
            Get = Snippet.From("value"),
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
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        Property.Methods? right = default!;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        Property.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        var right = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
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
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Property.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}