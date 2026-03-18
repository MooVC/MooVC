namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorMethodsMethodsIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property.Methods? left = default!;
        Property.Methods? right = default!;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Property.Methods? left = default!;
        var right = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        Property.Methods? right = default!;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        Property.Methods second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
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
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
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
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}