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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Direction).IsEqualTo(original.Direction);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(replacement);
        _ = await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}