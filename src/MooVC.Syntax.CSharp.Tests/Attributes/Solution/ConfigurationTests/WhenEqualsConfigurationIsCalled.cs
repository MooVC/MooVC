namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax.CSharp;

public sealed class WhenEqualsConfigurationIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Configuration subject = ConfigurationTestsData.Create();

        // Act
        bool result = subject.Equals(default(Configuration));

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Configuration subject = ConfigurationTestsData.Create();
        Configuration other = ConfigurationTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Configuration subject = ConfigurationTestsData.Create();
        Configuration other = ConfigurationTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}