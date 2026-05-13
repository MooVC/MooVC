namespace MooVC.Syntax.CSharp.OperatorsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        object? subject = default;
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenOperatorsThenReturnsTrue()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create();
        object target = OperatorsSubjectData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenWrongTypeThenReturnsFalse()
    {
        // Arrange
        object subject = new object();
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}