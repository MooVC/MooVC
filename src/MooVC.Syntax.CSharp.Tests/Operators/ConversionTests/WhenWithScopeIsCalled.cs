namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Scope replacement = Scope.Internal;

        // Act
        Conversion result = original.WithScope(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Direction).IsEqualTo(original.Direction);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Scope).IsEqualTo(replacement);
        await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}