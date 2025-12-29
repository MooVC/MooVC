namespace MooVC.Syntax.CSharp.Attributes.Project.SdkTests;

public sealed class WhenInequalityOperatorSdkSdkIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create(version: Snippet.From("2.0.0"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}