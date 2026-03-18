namespace MooVC.Syntax.CSharp.ParameterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(modifier: Parameter.Mode.In);
        Parameter right = ParameterTestsData.Create(modifier: Parameter.Mode.In);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(@default: Snippet.From("alpha"));
        Parameter right = ParameterTestsData.Create(@default: Snippet.From("beta"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}