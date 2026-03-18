namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter right = ParameterTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter right = ParameterTestsData.Create(name: new Name("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}