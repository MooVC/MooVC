namespace MooVC.Syntax.Project.ParameterTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create();
        var updated = new Name("Other");

        // Act
        Parameter result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}