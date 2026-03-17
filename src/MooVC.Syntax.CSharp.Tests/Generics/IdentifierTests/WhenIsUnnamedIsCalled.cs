namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenIsUnnamedIsCalled
{
    [Test]
    public void GivenUnnamedIdentifierThenReturnsTrue()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;

        // Act
        bool result = subject.IsUnnamed;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
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