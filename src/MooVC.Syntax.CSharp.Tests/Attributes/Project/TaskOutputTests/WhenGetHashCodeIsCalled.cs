namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}