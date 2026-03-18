namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        object? subject = default;
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenWrongTypeThenReturnsFalse()
    {
        // Arrange
        object subject = new();
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenOperatorsThenReturnsTrue()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create();
        object target = OperatorsSubjectData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }
}