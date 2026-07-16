namespace MooVC.Syntax.Project.OutputTests;

public sealed class WhenInequalityOperatorTaskOutputTaskOutputIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Output left = OutputTestsData.Create();
        Output right = OutputTestsData.Create(itemName: new Name("Other"));

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}