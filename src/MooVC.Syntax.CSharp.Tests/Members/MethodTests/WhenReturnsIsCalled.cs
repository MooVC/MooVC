namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

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
            Type = new Symbol { Name = "bool" },
        };

        // Act
        Method updated = original.Returns(result);

        // Assert
        await Assert.That(ReferenceEquals(updated, original)).IsFalse();
        await Assert.That(updated.Body).IsEqualTo(original.Body);
        await Assert.That(updated.Name).IsEqualTo(original.Name);
        await Assert.That(updated.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(updated.Result).IsEqualTo(result);
        await Assert.That(updated.Scope).IsEqualTo(original.Scope);
    }
}