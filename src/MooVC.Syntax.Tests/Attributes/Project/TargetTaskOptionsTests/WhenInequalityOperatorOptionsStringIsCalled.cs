namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenInequalityOperatorOptionsStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.ErrorAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left != Right;

        // Assert
        await Assert.That(result).IsTrue();
    }
}