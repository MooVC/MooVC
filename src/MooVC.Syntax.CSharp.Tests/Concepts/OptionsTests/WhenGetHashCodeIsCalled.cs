namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualOptionsThenHashCodesMatch()
    {
        // Arrange
        var left = new Options();
        var right = new Options();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentOptionsThenHashCodesDiffer()
    {
        // Arrange
        var left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}