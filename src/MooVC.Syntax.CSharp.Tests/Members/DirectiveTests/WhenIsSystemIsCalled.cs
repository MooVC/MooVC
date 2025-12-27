namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

public sealed class WhenIsSystemIsCalled
{
    [Fact]
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

    [Fact]
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