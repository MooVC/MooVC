namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenReturnsIsCalled
{
    [Test]
    public async Task GivenResultThenReturnsNewInstanceWithUpdatedResult()
    {
        // Arrange
        Method original = MethodTestsData.Create();
        var result = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new() { Name = "bool" },
        };

        // Act
        Method updated = original.Returns(result);

        // Assert
        _ = await Assert.That(updated).IsNotSameReferenceAs(original);
        _ = await Assert.That(updated.Body).IsEqualTo(original.Body);
        _ = await Assert.That(updated.Name).IsEqualTo(original.Name);
        _ = await Assert.That(updated.Parameters).IsEqualTo(original.Parameters);
        _ = await Assert.That(updated.Result).IsEqualTo(result);
        _ = await Assert.That(updated.Scope).IsEqualTo(original.Scope);
    }
}