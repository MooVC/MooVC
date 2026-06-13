namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public async Task GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Scopes left = Scopes.Private;
        Scopes right = Scopes.Public;

        // Act
        Func<Scopes> result = () => left + right;

        // Assert
        _ = await Assert.That(result).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task GivenNullLeftThenThrows()
    {
        // Arrange
        Scopes? left = default;
        Scopes right = Scopes.Public;

        // Act
        Func<Scopes> result = () => left! + right;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullRightThenThrows()
    {
        // Arrange
        Scopes left = Scopes.Public;
        Scopes? right = default;

        // Act
        Func<Scopes> result = () => left + right!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenPrivateProtectedThenCombinedScopeReturned()
    {
        // Arrange
        Scopes left = Scopes.Private;
        Scopes right = Scopes.Protected;

        // Act
        Scopes result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("private protected");
    }

    [Test]
    public async Task GivenProtectedInternalThenCombinedScopeReturned()
    {
        // Arrange
        Scopes left = Scopes.Protected;
        Scopes right = Scopes.Internal;

        // Act
        Scopes result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("protected internal");
    }
}