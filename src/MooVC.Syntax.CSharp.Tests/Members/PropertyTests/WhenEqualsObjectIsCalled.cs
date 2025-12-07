namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
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
        Property subject = PropertyTestsData.Create();
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
        Property subject = PropertyTestsData.Create();
        object target = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentTypeThenFalseIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        object target = PropertyTestsData.Create(name: "Other");

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}