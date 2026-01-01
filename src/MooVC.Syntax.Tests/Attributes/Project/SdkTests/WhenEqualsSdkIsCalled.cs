namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsSdkIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        Sdk? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        Sdk other = SdkTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        Sdk other = SdkTestsData.Create(version: Snippet.From("2.0.0"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}