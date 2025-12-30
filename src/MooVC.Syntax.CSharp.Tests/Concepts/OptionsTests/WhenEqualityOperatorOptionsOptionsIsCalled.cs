namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenEquivalentOptionsThenReturnsTrue()
    {
        // Arrange
        var left = new Options();
        var right = new Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentOptionsThenReturnsFalse()
    {
        // Arrange
        var left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}