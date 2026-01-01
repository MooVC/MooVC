namespace MooVC.Syntax.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorConfigurationConfigurationIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Configuration? left = default;
        Configuration? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Configuration left = ConfigurationTestsData.Create();
        Configuration right = ConfigurationTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Configuration left = ConfigurationTestsData.Create();
        Configuration right = ConfigurationTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}