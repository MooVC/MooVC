namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenEquivalentOptionsThenReturnsFalse()
    {
        // Arrange
        var left = new Options();
        var right = new Options();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentOptionsThenReturnsTrue()
    {
        // Arrange
        var left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}