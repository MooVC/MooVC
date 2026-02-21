namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Fact]
    public void GivenPrivateProtectedThenCombinedScopeReturned()
    {
        // Arrange
        Scope left = Scope.Private;
        Scope right = Scope.Protected;

        // Act
        Scope result = left + right;

        // Assert
        result.ToString().ShouldBe("private protected");
    }

    [Fact]
    public void GivenProtectedInternalThenCombinedScopeReturned()
    {
        // Arrange
        Scope left = Scope.Protected;
        Scope right = Scope.Internal;

        // Act
        Scope result = left + right;

        // Assert
        result.ToString().ShouldBe("protected internal");
    }

    [Fact]
    public void GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Scope left = Scope.Private;
        Scope right = Scope.Public;

        // Act
        Func<Scope> result = () => left + right;

        // Assert
        _ = result.ShouldThrow<InvalidOperationException>();
    }

    [Fact]
    public void GivenNullLeftThenThrows()
    {
        // Arrange
        Scope? left = default;
        Scope right = Scope.Public;

        // Act
        Func<Scope> result = () => left! + right;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenNullRightThenThrows()
    {
        // Arrange
        Scope left = Scope.Public;
        Scope? right = default;

        // Act
        Func<Scope> result = () => left + right!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }
}