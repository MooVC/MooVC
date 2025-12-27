namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenEquivalentOptionsThenReturnsFalse()
    {
        // Arrange
        Options left = new Options();
        Options right = new Options();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentOptionsThenReturnsTrue()
    {
        // Arrange
        Options left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}