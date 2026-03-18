namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithSdkIsCalled
{
    private const string UpdatedSdk = "UpdatedSdk";

    [Test]
    public async Task GivenSdkThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = Snippet.From(UpdatedSdk);

        // Act
        Import result = original.WithSdk(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Sdk).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Project).IsEqualTo(original.Project);
    }
}