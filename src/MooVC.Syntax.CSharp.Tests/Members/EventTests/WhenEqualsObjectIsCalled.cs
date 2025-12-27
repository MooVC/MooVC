namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        object? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        object target = EventTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        object target = new();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        object target = EventTestsData.Create(handler: "Result");

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}