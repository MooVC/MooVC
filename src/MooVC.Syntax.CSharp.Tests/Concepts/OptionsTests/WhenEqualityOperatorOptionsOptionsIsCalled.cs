namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenEquivalentOptionsThenReturnsTrue()
    {
        // Arrange
        Options left = new Options();
        Options right = new Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentOptionsThenReturnsFalse()
    {
        // Arrange
        Options left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}