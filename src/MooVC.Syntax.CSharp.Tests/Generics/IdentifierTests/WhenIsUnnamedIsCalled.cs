namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenIsUnnamedIsCalled
{
    [Fact]
    public void GivenUnnamedIdentifierThenReturnsTrue()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;

        // Act
        bool result = subject.IsUnnamed;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenNamedIdentifierThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier("TValue");

        // Act
        bool result = subject.IsUnnamed;

        // Assert
        result.ShouldBeFalse();
    }
}