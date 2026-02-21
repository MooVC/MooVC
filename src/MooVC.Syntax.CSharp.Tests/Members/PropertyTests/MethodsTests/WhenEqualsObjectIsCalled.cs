namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = "value",
        };

        object? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = "value",
            Set = new Property.Setter { Behaviour = "value = input" },
        };

        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = "value",
            Set = new Property.Setter { Behaviour = "value = input" },
        };

        object target = new Property.Methods
        {
            Get = "value",
            Set = new Property.Setter { Behaviour = "value = input" },
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentTypeThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = "value",
        };

        object target = new Property.Methods
        {
            Get = "alternative",
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}