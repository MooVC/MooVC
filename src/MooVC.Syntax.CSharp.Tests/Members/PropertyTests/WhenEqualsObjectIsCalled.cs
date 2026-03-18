namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        object? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        object target = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentTypeThenFalseIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        object target = PropertyTestsData.Create(name: "Other");

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}