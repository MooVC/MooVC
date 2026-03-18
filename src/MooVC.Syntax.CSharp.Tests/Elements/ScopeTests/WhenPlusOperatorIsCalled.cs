namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public async Task GivenPrivateProtectedThenCombinedScopeReturned()
    {
        // Arrange
        Scope left = Scope.Private;
        Scope right = Scope.Protected;

        // Act
        Scope result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("private protected");
    }

    [Test]
    public async Task GivenProtectedInternalThenCombinedScopeReturned()
    {
        // Arrange
        Scope left = Scope.Protected;
        Scope right = Scope.Internal;

        // Act
        Scope result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("protected internal");
    }

    [Test]
    public async Task GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Scope left = Scope.Private;
        Scope right = Scope.Public;

        // Act
        Func<Scope> result = () => left + right;

        // Assert
        _ = await Assert.That(result).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task GivenNullLeftThenThrows()
    {
        // Arrange
        Scope? left = default;
        Scope right = Scope.Public;

        // Act
        Func<Scope> result = () => left! + right;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullRightThenThrows()
    {
        // Arrange
        Scope left = Scope.Public;
        Scope? right = default;

        // Act
        Func<Scope> result = () => left + right!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}