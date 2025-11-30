namespace MooVC.Syntax.CSharp.Members.ParameterTests.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        var left = new Parameter.Options();
        var right = new Parameter.Options();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var left = new Parameter.Options();
        var right = new Parameter.Options().WithNaming(Identifier.Options.Pascal);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}
