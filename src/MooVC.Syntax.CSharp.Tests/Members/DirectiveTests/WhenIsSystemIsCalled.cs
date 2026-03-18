namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenIsSystemIsCalled
{
    [Test]
    public void GivenSystemQualifierThenReturnsTrue()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier(["System", "Linq"]),
        };

        // Act
        bool result = subject.IsSystem;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenNonSystemQualifierThenReturnsFalse()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        bool result = subject.IsSystem;

        // Assert
        result.ShouldBeFalse();
    }
}