namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Unary original = UnaryTestsData.Create();
        Scope replacement = Scope.Private;

        // Act
        Unary result = original.WithScope(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Operator).IsEqualTo(original.Operator);
        await Assert.That(result.Scope).IsEqualTo(replacement);
    }
}