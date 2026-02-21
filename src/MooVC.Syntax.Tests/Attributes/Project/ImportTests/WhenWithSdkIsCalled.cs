namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithSdkIsCalled
{
    private const string UpdatedSdk = "UpdatedSdk";

    [Fact]
    public void GivenSdkThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = UpdatedSdk;

        // Act
        Import result = original.WithSdk(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Sdk.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Project.ShouldBe(original.Project);
    }
}