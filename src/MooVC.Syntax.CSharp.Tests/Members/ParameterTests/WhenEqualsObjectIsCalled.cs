namespace MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        object comparison = string.Empty;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create(modifier: Parameter.Mode.Out);
        object comparison = ParameterTestsData.Create(modifier: Parameter.Mode.Out);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }
}