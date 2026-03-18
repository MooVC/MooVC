namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenIsSystemIsCalled
{
    [Test]
    public async Task GivenSystemQualifierThenReturnsTrue()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier(["System", "Linq"]),
        };

        // Act
        bool result = subject.IsSystem;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonSystemQualifierThenReturnsFalse()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        bool result = subject.IsSystem;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}