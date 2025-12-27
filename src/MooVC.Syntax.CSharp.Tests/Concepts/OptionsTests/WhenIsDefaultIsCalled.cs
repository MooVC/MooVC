namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

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
            .WithNamespace(Members.Qualifier.Options.Block);

        // Act
        bool result = subject.IsDefault;

        // Assert
        result.ShouldBeFalse();
    }
}