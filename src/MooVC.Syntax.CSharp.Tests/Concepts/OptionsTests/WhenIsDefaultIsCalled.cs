namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenIsDefaultIsCalled
{
    [Fact]
    public void GivenDefaultValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Options();

        // Act
        bool result = subject.IsDefault;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
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