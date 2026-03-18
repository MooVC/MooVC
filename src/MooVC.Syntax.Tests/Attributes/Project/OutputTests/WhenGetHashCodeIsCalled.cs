namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Output left = OutputTestsData.Create();
        Output right = OutputTestsData.Create();

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
        Output left = OutputTestsData.Create();
        Output right = OutputTestsData.Create(itemName: new Name("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}