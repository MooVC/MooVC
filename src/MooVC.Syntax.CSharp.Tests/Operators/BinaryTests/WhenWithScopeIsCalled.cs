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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Operator).IsEqualTo(original.Operator);
        _ = await Assert.That(result.Scope).IsEqualTo(replacement);
    }
}