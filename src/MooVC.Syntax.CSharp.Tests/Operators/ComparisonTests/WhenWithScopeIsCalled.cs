namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        Scope replacement = Scope.Private;

        // Act
        Comparison result = original.WithScope(replacement);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Operator).IsEqualTo(original.Operator);
        _ = await Assert.That(result.Scope).IsEqualTo(replacement);
    }
}