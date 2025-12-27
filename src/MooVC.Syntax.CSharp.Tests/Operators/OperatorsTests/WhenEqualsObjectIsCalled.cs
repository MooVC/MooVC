namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
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

    [Fact]
    public void GivenWrongTypeThenReturnsFalse()
    {
        // Arrange
        object subject = new object();
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
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