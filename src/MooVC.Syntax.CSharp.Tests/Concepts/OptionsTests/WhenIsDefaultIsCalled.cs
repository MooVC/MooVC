namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenIsDefaultIsCalled
{
    [Test]
    public void GivenDefaultValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Options();

        // Act
        bool result = subject.IsDefault;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenNonDefaultValuesThenReturnsFalse()
    {
        // Arrange
        Options subject = new Options()
            .WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = subject.IsDefault;

        // Assert
        result.ShouldBeFalse();
    }
}