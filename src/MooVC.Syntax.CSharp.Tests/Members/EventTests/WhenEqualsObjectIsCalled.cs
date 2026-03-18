namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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