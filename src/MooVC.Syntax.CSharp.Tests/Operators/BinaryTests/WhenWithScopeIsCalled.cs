namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Binary original = BinaryTestsData.Create();
        Scope replacement = Scope.Internal;

        // Act
        Binary result = original.WithScope(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Operator).IsEqualTo(original.Operator);
        await Assert.That(result.Scope).IsEqualTo(replacement);
    }
}