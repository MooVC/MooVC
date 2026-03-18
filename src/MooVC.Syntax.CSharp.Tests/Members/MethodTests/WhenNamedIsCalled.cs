namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Name).IsEqualTo(new Declaration { Name = NewName });
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(original.Name).IsEqualTo(new Declaration { Name = MethodTestsData.DefaultName });
    }
}