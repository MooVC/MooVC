namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "Other";

    [Test]
    public async Task GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Method original = MethodTestsData.Create();

        // Act
        Method result = original.Named(new Declaration { Name = NewName });

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Name).IsEqualTo(new Declaration { Name = NewName });
        _ = await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        _ = await Assert.That(result.Result).IsEqualTo(original.Result);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(original.Name).IsEqualTo(new Declaration { Name = MethodTestsData.DefaultName });
    }
}