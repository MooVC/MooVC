namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsTaskParameterIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter other = ParameterTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter other = ParameterTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}