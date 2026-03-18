namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        var right = new File(FileTestsData.DefaultPath);

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
        var left = new File(FileTestsData.DefaultPath);
        var right = new File("assets/other.cs");

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}