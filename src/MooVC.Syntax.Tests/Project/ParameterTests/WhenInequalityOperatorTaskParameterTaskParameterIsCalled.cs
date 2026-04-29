namespace MooVC.Syntax.Project.ParameterTests;

public sealed class WhenInequalityOperatorTaskParameterTaskParameterIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter right = ParameterTestsData.Create(name: new Name("Other"));

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}