namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsTaskParameterIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter other = ParameterTestsData.Create(name: new Name("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}