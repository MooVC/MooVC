namespace MooVC.Syntax.CSharp.Elements.ParameterTests.OptionsTests;

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

        Parameter.Options right = new Parameter.Options()
            .WithNaming(Identifier.Options.Pascal);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}