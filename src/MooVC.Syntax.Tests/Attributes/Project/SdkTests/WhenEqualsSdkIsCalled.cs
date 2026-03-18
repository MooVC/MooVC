namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsSdkIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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