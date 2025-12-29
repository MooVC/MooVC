namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTests;

public sealed class WhenEqualsTargetIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        Target? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        Target other = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        Target other = TargetTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}