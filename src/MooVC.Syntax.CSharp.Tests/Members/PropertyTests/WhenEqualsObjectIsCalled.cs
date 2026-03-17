namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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