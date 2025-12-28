namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(modifier: Parameter.Mode.In);
        Parameter right = ParameterTestsData.Create(modifier: Parameter.Mode.In);

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
        Parameter left = ParameterTestsData.Create(@default: Snippet.From("alpha"));
        Parameter right = ParameterTestsData.Create(@default: Snippet.From("beta"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}