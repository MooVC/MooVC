namespace MooVC.Syntax.CSharp.Attributes.Project.SdkTests;

public sealed class WhenEqualityOperatorSdkSdkIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Sdk? left = default;
        Sdk? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create(version: Snippet.From("2.0.0"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}