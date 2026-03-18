namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        const string name = "ProjectName";
        var subject = new Project.Name(name);

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(name);
    }
}