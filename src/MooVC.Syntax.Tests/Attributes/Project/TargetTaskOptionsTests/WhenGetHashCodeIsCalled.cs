namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.WarnAndContinue;

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
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}